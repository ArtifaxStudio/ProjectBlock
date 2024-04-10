using System;
using UnityEngine;

namespace Artifax.Framework
{
    [Serializable]
    public class IntReference
    {
        public bool UseConstant = true;
        [SerializeField]
        protected int m_ConstantValue;
        public IntVarible Variable;

        public int Value
        {
            get { return UseConstant ? m_ConstantValue : Variable.Value; }
        }

        public static implicit operator int(IntReference reference)
        {
            return reference.Value;
        }
    }
}
