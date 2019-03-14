using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OFP.ObjectModel.Platform.Types
{
    /// <summary>
    /// ОписаниеТипов.
    /// </summary>
    public class TypeDescription : IEnumerable<TypeQualifier>
    {
        private readonly List<TypeQualifier> _qualifiers;

        public TypeDescription()
        {
            _qualifiers = new List<TypeQualifier>();
        }

        public void Add(TypeQualifier qualifier)
        {
            if (qualifier.Type != PlatformType.Ref)
            {
                var oldQualifier = _qualifiers
                    .Where(q => q.Type == qualifier.Type)
                    .FirstOrDefault();
                if (oldQualifier != null)
                {
                    _qualifiers.Remove(oldQualifier);
                }
            }

            _qualifiers.Add(qualifier);
        }

        public bool Remove(TypeQualifier qualifier)
        {
            return _qualifiers.Remove(qualifier);
        }

        public IEnumerator<TypeQualifier> GetEnumerator()
        {
            return _qualifiers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
