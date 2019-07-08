using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class TreeViewWindow : EditorWindow
{
    [MenuItem("Window/Game/Tree")]
    public static void OpenSomeWindow()
    {
        // ein neues fenster öffnen, falls noch keines offen ist.
        TreeViewWindow window = EditorWindow.GetWindow<TreeViewWindow>();

        window.items 
            = new ItemsTreeView(FindObjectsOfType<Item>().ToList());
        window.items.Reload();
    }

    private ItemsTreeView items;

    private void OnGUI()
    {
        items.OnGUI(new Rect(0, 0, 600, 400));
    }
}
