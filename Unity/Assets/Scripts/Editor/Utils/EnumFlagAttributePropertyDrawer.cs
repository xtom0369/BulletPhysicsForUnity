using System;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(EnumFlagAttribute))]
class EnumFlagAttributePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label = EditorGUI.BeginProperty(position, label, property);

        var oldValue = (Enum)fieldInfo.GetValue(property.serializedObject.targetObject);
        var newValue = EditorGUI.EnumFlagsField(position, label, oldValue);
        if (!newValue.Equals(oldValue))
        {
            property.intValue = (int)Convert.ChangeType(newValue, fieldInfo.FieldType);
        }

        EditorGUI.EndProperty();
    }
}