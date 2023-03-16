using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePart : MonoBehaviour
{
    public string objectReqName;
    public bool partCorrect = false;
    public DemoPuzzle puzzle;
    public InventoryBase inventory;
    public Material correctMat;
    public GameObject sprite;

    public void CheckObject(string objName) //se llama desde player, comprueba si el objeto que esta sujetando el jugador es el indicado para esta Part
    {
        if (objName == objectReqName)
        {
            partCorrect = true;
            puzzle.CheckParts();
            Debug.Log(objName + "Has been accepted");
            sprite.SetActive(false);
            GetComponent<MeshRenderer>().material = correctMat;
        }
    }
}
