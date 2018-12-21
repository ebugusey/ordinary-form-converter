using System;
using System.Buffers;
using System.IO;
using BufferStorage = System.Collections.Generic.Dictionary<long, byte[]>;

namespace libUnpack.Test.Mock
{
    sealed class SparseMemoryStream : Stream
    {
        public override bool CanRead { get; }
        public override bool CanSeek { get; }
        public override bool CanWrite { get; }
        public override long Length => _length;
        public override long Position
        {
            get => _position;
            set => _position = value;
        }

        private const int BufSize = 4096;

        private long BufferStart
            // Здесь деление целочисленное.
            => _position / BufSize * BufSize;
        private int BufferPosition
            => (int)(_position - BufferStart);

        private readonly BufferStorage _buffers = new BufferStorage();
        private readonly byte[] _emptyBuffer;
        private readonly ArrayPool<byte> _bufferPool;

        private long _length;
        private long _position;

        public static SparseMemoryStream ReadOnlyStream(long length)
        {
            return new SparseMemoryStream(canRead: true, canWrite: false, canSeek: true, length: length);
        }

        public static SparseMemoryStream WritableStream(long length = 0)
        {
            return new SparseMemoryStream(canRead: true, canWrite: true, canSeek: true, length: length);
        }

        public SparseMemoryStream(bool canRead = true, bool canWrite = true, bool canSeek = true, long length = 0)
        {
            (CanRead, CanWrite, CanSeek) = (canRead, canWrite, canSeek);
            _length = length;

            _bufferPool = ArrayPool<byte>.Shared;

            _emptyBuffer = _bufferPool.Rent(BufSize);
            _emptyBuffer.AsSpan().Fill(0);
        }

        public override void Flush()
        {
            
        }

        public override int Read(Span<byte> buffer)
        {
            if (_position >= _length)
            {
                return 0;
            }

            var bytesRead = ReadData(buffer);

            _position += bytesRead;

            return bytesRead;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return Read(buffer.AsSpan(offset, count));
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    _position = offset;
                    break;
                case SeekOrigin.Current:
                    _position += offset;
                    break;
                case SeekOrigin.End:
                    _position = _length + offset;
                    break;
                default:
                    break;
            }

            return _position;
        }

        public override void SetLength(long value)
        {
            _length = value;
        }

        public override void Write(ReadOnlySpan<byte> buffer)
        {
            var currentBuffer = buffer;
            while (!currentBuffer.IsEmpty)
            {
                var bytesWritten = WriteData(currentBuffer);
                currentBuffer = currentBuffer.Slice(Math.Min(bytesWritten, currentBuffer.Length));
                _position += bytesWritten;
            }

            if (_length < _position)
            {
                _length = _position;
            }
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Write(new ReadOnlySpan<byte>(buffer, offset, count));
        }

        private int ReadData(Span<byte> data)
        {
            var buffer = GetBuffer();
            var dataToRead = data.Slice(0, Math.Min(buffer.Length, data.Length));
            buffer.Slice(0, dataToRead.Length).CopyTo(dataToRead);

            return dataToRead.Length;
        }

        private int WriteData(ReadOnlySpan<byte> data)
        {
            var buffer = GetBuffer(createIfDoesntExist: true);
            var dataToWrite = data.Slice(0, Math.Min(buffer.Length, data.Length));
            dataToWrite.CopyTo(buffer);

            FreeBufferIfEmpty();

            return dataToWrite.Length;
        }

        private Span<byte> GetBuffer(bool createIfDoesntExist = false)
        {
            var key = BufferStart;

            Span<byte> result;
            if (_buffers.TryGetValue(key, out var buffer))
            {
                result = buffer.AsSpan(0, BufSize);
            }
            else if (createIfDoesntExist)
            {
                buffer = _bufferPool.Rent(BufSize);
                _buffers.Add(key, buffer);

                result = buffer.AsSpan(0, BufSize);
                result.Fill(0);
            }
            else
            {
                result = _emptyBuffer.AsSpan(0, BufSize);
            }

            return result.Slice(BufferPosition);
        }

        private void FreeBufferIfEmpty()
        {
            var key = BufferStart;
            if (!_buffers.TryGetValue(key, out var buffer))
            {
                return;
            }

            bool bufferHasData = false;
            foreach (var @byte in buffer.AsSpan(0, BufSize))
            {
                if (@byte != 0)
                {
                    bufferHasData = true;
                    break;
                }
            }
            if (!bufferHasData)
            {
                _buffers.Remove(key);
                _bufferPool.Return(buffer);
            }
        }

        #region IDisposable

        private bool _disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _bufferPool.Return(_emptyBuffer);

                foreach (var buffer in _buffers.Values)
                {
                    _bufferPool.Return(buffer);
                }

                _buffers.Clear();
            }

            _disposed = true;

            base.Dispose(disposing);
        }

        #endregion
    }
}
