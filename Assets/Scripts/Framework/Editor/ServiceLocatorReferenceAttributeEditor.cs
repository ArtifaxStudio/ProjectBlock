using Artifax.Framework;
using Artifax.ProjectBlock.Framework;
using UnityEditor;
using UnityEngine;

namespace Artifax.ProjectBlock.Editor
{
    [CustomPropertyDrawer(typeof(ServiceLocatorReferenceAttribute))]
    public class ServiceLocatorReferenceAttributeEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label);

            if (property.propertyType == SerializedPropertyType.ObjectReference && property.objectReferenceValue == null)
            {
                var fieldType = fieldInfo.FieldType;

                if (typeof(ServiceLocator).IsAssignableFrom(fieldType))
                {
                    var assets = AssetDatabase.FindAssets($"t:{fieldType.Name}");
                    if (assets.Length > 0)
                    {
                        var path = AssetDatabase.GUIDToAssetPath(assets[0]);
                        var asset = AssetDatabase.LoadAssetAtPath(path, fieldType);

                        if (asset != null)
                        {
                            property.objectReferenceValue = asset;
                            property.serializedObject.ApplyModifiedProperties();
                        }
                    }
                    else
                    {
                        Debug.LogWarning($"Asset of type {fieldType.Name} wasn't found");
                    }
                }
                else
                {
                    Debug.LogWarning($"Type {fieldType.Name} is not a ScriptableObject valid type.");
                }
            }
        }
    }
}
