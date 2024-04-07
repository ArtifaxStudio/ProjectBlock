using UnityEditor;

namespace Artifax.Framework.Utils
{
    [CustomEditor(typeof(ServiceLocator))]
    public class ServiceLocatorEditor : Editor
    {
        private ServiceLocator m_ServiceLocator;

        private void OnEnable()
        {
            m_ServiceLocator = (ServiceLocator)target;
        }

        public override void OnInspectorGUI()
        {
            if (m_ServiceLocator == null)
                return;

            EditorGUILayout.LabelField("SERVICES", EditorStyles.boldLabel);

            EditorGUI.indentLevel++;
            foreach (var service in m_ServiceLocator.Services)
            {
                EditorGUILayout.LabelField(service.Key.Name);
            }
            EditorGUI.indentLevel--;
        }
    }
}
