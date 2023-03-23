using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new_item", menuName = "ScriptableObjects/Create new item")]
public class Item : ScriptableObject
{
    public string id;
    public GameObject spritePrefab;
    public bool inInventory;
    public Item thisItem;

    public void SelectThisItem() //con boton se activa, la funcion guarda el boton clicado
    {
        Player[] players = FindObjectsOfType<Player>();
        foreach (Player p in players)
        {
            p.SelectItem(thisItem);
        }
        
    }
}
