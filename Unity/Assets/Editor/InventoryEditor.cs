using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor
{

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var entries = serializedObject.FindProperty("Entries");

        EditorGUILayout.LabelField("Entries");
        foreach(SerializedProperty entry in entries)
        {
            DrawEntry(entry);
        }

        if(GUILayout.Button("Add"))
        {
            entries.InsertArrayElementAtIndex(entries.arraySize);
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawEntry(SerializedProperty property)
    {
        var itemProperty = property.FindPropertyRelative("Item");
        var nameProperty = itemProperty.FindPropertyRelative("Name");
        var amountProperty = property.FindPropertyRelative("Amount");

        EditorGUILayout.BeginHorizontal();

        property.isExpanded = EditorGUILayout.Foldout(property.isExpanded, nameProperty?.stringValue ?? "None");
        if (property.isExpanded)
        {

            EditorGUILayout.ObjectField(itemProperty, new GUIContent());
            amountProperty.intValue
                            = EditorGUILayout.IntField(amountProperty.intValue);
        }

        if(GUILayout.Button("Delete"))
        {
            property.DeleteCommand();
        }

        EditorGUILayout.EndHorizontal();
    }

}
