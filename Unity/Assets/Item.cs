using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    WEAPON, SHIELD, POTION
}

public class Item : MonoBehaviour
{

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
