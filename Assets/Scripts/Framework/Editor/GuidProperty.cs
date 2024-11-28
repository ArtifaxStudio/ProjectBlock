using Artifax.ProjectBlock.Framework;
using System;
using UnityEditor;
using UnityEngine;

namespace Artifax.ProjectBlock.EditorApplication
{
    [CustomPropertyDrawer(typeof(Framework.GUID))]
    public class SerializableGuidDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            Rect labelRect = new Rect(position.x, position.y, EditorGUIUtility.labelWidth, position.height);
            Rect valueRect = new Rect(labelRect.xMax, position.y, position.width - EditorGUIUtility.labelWidth - 90, position.height);
            Rect pasteButtonRect = new Rect(valueRect.xMax + 5, position.y, 25, position.height);
            Rect copyButtonRect = new Rect(pasteButtonRect.xMax + 5, position.y, 25, position.height);
            Rect regenerateButtonRect = new Rect(copyButtonRect.xMax + 5, position.y, 25, position.height);

            EditorGUI.LabelField(labelRect, label);

            SerializedProperty guidValueProp = property.FindPropertyRelative("guidValue");
            string guidValue = guidValueProp.stringValue;

            EditorGUI.SelectableLabel(valueRect, guidValue);

            if (UnityEngine.GUI.Button(pasteButtonRect, EditorGUIUtility.IconContent("SceneLoadOut", "Paste")))
            {
                string clipboardValue = EditorGUIUtility.systemCopyBuffer;

                if (Guid.TryParse(clipboardValue, out var parsedGuid))
                {
                    guidValueProp.stringValue = clipboardValue;
                    Debug.Log($"GUID pasted from clipboard: {clipboardValue}");
                }
                else
                {
                    Debug.LogWarning("Clipboard content is not a valid GUID.");
                }
            }

            if (UnityEngine.GUI.Button(copyButtonRect, EditorGUIUtility.IconContent("SceneLoadIn", "Copy")))
            {
                EditorGUIUtility.systemCopyBuffer = guidValue;
                Debug.Log($"GUID copied: {guidValue}");
            }

            if (UnityEngine.GUI.Button(regenerateButtonRect, EditorGUIUtility.IconContent("Refresh")))
            {
                string newGuid = Guid.NewGuid().ToString();
                guidValueProp.stringValue = newGuid; // Update the GUID value
                Debug.Log($"New GUID generated: {newGuid}");
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }
}
