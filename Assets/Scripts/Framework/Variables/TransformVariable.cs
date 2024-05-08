using UnityEngine;

namespace Artifax.Framework
{
    [CreateAssetMenu(fileName = nameof(TransformVariable), menuName = ArtifaxScriptablePaths.VARIABLES_SCRIPTABLE_PATH + nameof(TransformVariable))]
    public class TransformVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        [SerializeField]
        private Transform m_Value = null;

        public delegate void VariableDelegate();
        public event VariableDelegate OnVariableUpdate;

        public Transform Value
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
