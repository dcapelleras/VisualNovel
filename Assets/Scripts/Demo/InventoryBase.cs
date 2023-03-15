using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Create new inventory")]
public class InventoryBase : ScriptableObject
{
    public List<string> inventoryItems = new List<string>();
}
