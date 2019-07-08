using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

public class SomeWindow : EditorWindow
{

    [MenuItem("Window/Game/SomeWindow")]
    public static void OpenSomeWindow()
    {
        // ein neues fenster öffnen, falls noch keines offen ist.
        EditorWindow.GetWindow<SomeWindow>();
    }

    private bool m_itemsOpen = false;

    private bool m_priceSortDirection = true;

    private ItemType m_filteredItemType = ItemType.NONE;

    /// <summary>
    /// Render the window gui.
    /// </summary>
    private void OnGUI()
    {
        m_itemsOpen = EditorGUILayout.Foldout(m_itemsOpen, "Items");

        if(m_itemsOpen)
        {
            EditorGUI.indentLevel++;
            OnItemsGUI();
            EditorGUI.indentLevel--;
        }
    }

    //private ReorderableList m_items;

    /// <summary>
    /// renders the items list.
    /// </summary>
    private void OnItemsGUI()
    {
        // find all items
        Item[] items = Object.FindObjectsOfType<Item>();

        /*
        if (m_items == null)
        {
            m_items = new ReorderableList((new string[] { "1", "2" }).ToList(), typeof(string));
            m_items.onAddCallback += (ReorderableList list) => list.list.Add("");
        }

        m_items.DoLayoutList();
        */       

        // render the table header
        RenderItemFilter();
        RenderItemHeader();

        // filter according to type
        if (m_filteredItemType != ItemType.NONE)
            items = items
                .Where(i => (i.Type & m_filteredItemType) != 0)
                .ToArray();

        // sort by price
        if (m_priceSortDirection)
            items = items.OrderBy(i => i.Price).ToArray();
        else
            items = items.OrderByDescending(i => i.Price).ToArray();

        // render the table body
        foreach (var item in items)
        {
            RenderItem(item);
        }
    }

    /// <summary>
    /// Renders the item filter.
    /// </summary>
    private void RenderItemFilter()
    {
        EditorGUILayout.BeginHorizontal();

        m_filteredItemType
            = (ItemType)EditorGUILayout.EnumFlagsField(m_filteredItemType);

        EditorGUILayout.EndHorizontal();
    }

    /// <summary>
    /// Renders the item header.
    /// </summary>
    private void RenderItemHeader()
    {
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("Name");

        EditorGUILayout.LabelField("Stack Size");

        if (GUILayout.Button("Price"))
        {
            m_priceSortDirection = !m_priceSortDirection;
        }

        EditorGUILayout.LabelField("");

        EditorGUILayout.EndHorizontal();
    }

    /// <summary>
    /// Renders the item.
    /// </summary>
    /// <param name="item">Item.</param>
    private void RenderItem(Item item)
    {
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField(item.Name);

        EditorGUILayout.LabelField(item.StackSize.ToString());
        EditorGUILayout.LabelField(item.Price.ToString());

        if (GUILayout.Button("Select"))
        {
            Selection.activeGameObject = item.gameObject;
        }

        EditorGUILayout.EndHorizontal();
    }

}
