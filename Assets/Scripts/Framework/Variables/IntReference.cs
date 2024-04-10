using System;
using UnityEngine;

namespace Artifax.Framework
{
    [Serializable]
    public class IntReference
    {
        public delegate void ReferenceDelegate();

        public bool UseConstant = true;
        [SerializeField]
        protected int m_ConstantValue;
        public IntVariable Variable;

        public event ReferenceDelegate OnReferenceUpdate;

        public int Value
        {
            get { return UseConstant ? m_ConstantValue : Variable.Value; }
            set
            {
                if(UseConstant)
                    m_ConstantValue = value;
                else
                    Variable.Value = value;

                OnReferenceUpdate?.Invoke();
            }
        }

        public static implicit operator int(IntReference reference)
        {
            return reference.Value;
        }
    }
}
