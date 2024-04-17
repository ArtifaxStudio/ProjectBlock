using UnityEngine;

namespace Artifax.Framework
{
    [CreateAssetMenu]
    public class IntVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        [SerializeField]
        private int m_Value = 0;

        public delegate void VariableDelegate();
        public event VariableDelegate OnVariableUpdate;

        public int Value
        {
            get { return m_Value; }
            set 
            { 
                m_Value = value;
                OnVariableUpdate?.Invoke();
            }
        }
    }
}
