using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Create new inventory")]
public class InventoryBase : ScriptableObject //base para crear inventarios que se pueden compartir entre mas de un objeto
{
    public List<string> inventoryItems = new List<string>();
}
