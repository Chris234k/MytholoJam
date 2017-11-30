using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// https://docs.unity3d.com/ScriptReference/PropertyDrawer.html
// 
[CustomPropertyDrawer(typeof(Ability))]
public class AbilityDrawer : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var unlockedRect = new Rect(position.x, position.y, 30, position.height);
        var keycodeRect = new Rect(position.x + 35, position.y, 75, position.height);
        var cooldownRect = new Rect(position.x + 125, position.y, 50, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(unlockedRect, property.FindPropertyRelative("unlocked"), GUIContent.none);
        EditorGUI.PropertyField(keycodeRect, property.FindPropertyRelative("keycode"), GUIContent.none);
        EditorGUI.PropertyField(cooldownRect, property.FindPropertyRelative("cooldown"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}