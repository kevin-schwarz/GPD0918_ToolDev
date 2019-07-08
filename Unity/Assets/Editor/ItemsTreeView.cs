using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;

public class ItemsTreeView : TreeView
{

    private List<Item> items = new List<Item>();

    public ItemsTreeView(List<Item> items)
        : base(new TreeViewState())
    {
        this.items = items;
    }

    protected override TreeViewItem BuildRoot()
    {
        int nextId = 0;
        var root = new TreeViewItem(nextId++, -1, "Root");

        foreach(ItemType type in System.Enum.GetValues(typeof(ItemType)))
        {
            if (type == ItemType.NONE)
                continue;

            var typeItem = new TreeViewItem(nextId++, 0, type.ToString());
            root.AddChild(typeItem);

            foreach(var item in items.Where(i => (i.Type & type) != 0))
            {
                var itemItem = new TreeViewItem(nextId++, 1, item.name);
                typeItem.AddChild(itemItem);
            }
        }

        return root;
    }

}
