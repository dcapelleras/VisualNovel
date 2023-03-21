using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new_item", menuName = "ScriptableObjects/Create new item")]
public class Item : ScriptableObject
{
    public string id;
    public GameObject spritePrefab;
    public GameObject spriteInstance; //dice type missmatch :'(
    public bool inInventory;
}
