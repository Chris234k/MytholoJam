using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// https://docs.unity3d.com/ScriptReference/PropertyDrawer.html
// 
[CustomPropertyDrawer(typeof(StatBonus))]
public class StatBonusDrawer : PropertyDrawer
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
        var bonusRect = new Rect(position.x + 35, position.y, 50, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(unlockedRect, property.FindPropertyRelative("unlocked"), GUIContent.none);
        EditorGUI.PropertyField(bonusRect, property.FindPropertyRelative("bonus"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}