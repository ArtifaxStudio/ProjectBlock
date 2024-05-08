using System;
using UnityEngine;

namespace Artifax.Framework
{
    [Serializable]
    public class TransformReference
    {
        public bool UseConstant = true;
        [SerializeField]
        protected Transform m_ConstantValue;
        public TransformVariable Variable;

        public delegate void ReferenceDelegate();
        public event ReferenceDelegate OnReferenceUpdate;

        public Transform Value
        {
            get { return UseConstant ? m_ConstantValue : Variable.Value; }
            set
            {
                if (UseConstant)
                    m_ConstantValue = value;
                else
                    Variable.Value = value;

                OnReferenceUpdate?.Invoke();
            }
        }

        private void VariableUpdated()
        {
            OnReferenceUpdate?.Invoke();
        }

        public static implicit operator Transform(TransformReference reference)
        {
            return reference.Value;
        }
    }
}
