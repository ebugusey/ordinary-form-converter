namespace libUnpack
{
    /// <summary>
    /// Режим работы контейнера.
    /// </summary>
    public enum V8ContainerMode
    {
        /// <summary>
        /// Контейнер открыт только для чтения.
        /// </summary>
        Read = 0,

        /// <summary>
        /// Контейнер открыт только для записи.
        /// </summary>
        Write = 1,
    }
}
