using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(InventoryEntry))]
public class InventoryEntryPropertyDrawer : PropertyDrawer
{

    public float GetPropertyHeight_LikeUnity(SerializedProperty property, GUIContent label)
    {
        return property.isExpanded ? 50 : 17;
    }

    public void OnGUI_LikeUnity(Rect position, SerializedProperty property, GUIContent label)
    {
        position.height = 17;
        property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, label);

        if (property.isExpanded)
        {
            EditorGUI.indentLevel++;

            // property enthält ein InventoryEntry
            // itemProperty enthält InventoryEntry.Item
            var itemProperty = property.FindPropertyRelative("Item");
            position.y += 18;
            EditorGUI.ObjectField(position, itemProperty, typeof(Item));

            var amountProperty = property.FindPropertyRelative("Amount");
            position.y += 18;
            amountProperty.intValue 
                = EditorGUI.IntField(position, "Amount", amountProperty.intValue);

            property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel--;
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var itemProperty = property.FindPropertyRelative("Item");
        var amountProperty = property.FindPropertyRelative("Amount");

        position.width /= 2;
        amountProperty.intValue
                = EditorGUI.IntField(position, label, amountProperty.intValue);
        position.x = position.width;
        EditorGUI.ObjectField(position, itemProperty, new GUIContent(""));

        // änderungen übernehmen
        property.serializedObject.ApplyModifiedProperties();
    }

}
