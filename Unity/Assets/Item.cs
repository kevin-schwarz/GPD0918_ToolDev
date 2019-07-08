using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    NONE    = 0,
    WEAPON  = 1,
    SHIELD  = 2,
    POTION  = 4
}

public class Item : MonoBehaviour
{

    public string Name;

    [Header("Market Data")]
    [Range(0, 100)]
    public int Price;

    [Range(1, 64)]
    public int StackSize;

    public int StackPrice;// = Price * StackSize;

    [Header("Basic Data")]
    [TextArea(3, 10)]
    public string Description;

    public ItemType Type;

}
