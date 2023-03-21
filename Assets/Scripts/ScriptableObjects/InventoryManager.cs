using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    Transform spritesInventory;
    public static InventoryManager instance;
    [SerializeField] Inventory inventory;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    public void UpdateInventory()
    {
        for (int i = 0; i < inventory.inventoryItems.Count; i++)
        {
            if (inventory.inventoryItems[i].inInventory)
            {
                if (inventory.inventoryItems[i].spriteInstance == null)
                {
                    inventory.inventoryItems[i].spriteInstance = Instantiate(inventory.inventoryItems[i].spritePrefab, spritesInventory);
                }
            }
            else
            {
                Destroy(inventory.inventoryItems[i].spriteInstance);
            }
        }
    }
}
