using System;
using UnityEngine;

namespace Artifax.ProjectBlock.Framework
{
    [Serializable]
    public class GUID
    {
        [SerializeField] private string guidValue;

        public GUID()
        {
            guidValue = Guid.NewGuid().ToString();
        }

        public GUID(string guid)
        {
            guidValue = guid;
        }

        public Guid Guid => Guid.TryParse(guidValue, out var result) ? result : Guid.Empty;

        public override string ToString() => guidValue;

        public static bool operator ==(GUID lhs, GUID rhs)
        {
            if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null)) return true;

            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) return false;

            return lhs.Guid == rhs.Guid;
        }

        public static bool operator !=(GUID lhs, GUID rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            if (obj is GUID other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }
    }
}
