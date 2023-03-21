using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Item thisItem;

    public Transform moveToPosition; //place where the player moves to pick it up

    [SerializeField] Material normalMat;
    [SerializeField] Material highlightMat;

    public void Interact() //should add to inventory
    {
        Debug.Log("You just interacted with " + gameObject.name);
        //add to inventory
        Disappear();
    }

    void Disappear()
    {
        gameObject.SetActive(false);
    }

    private void OnMouseEnter()
    {
        transform.GetComponent<Renderer>().material = highlightMat;
    }

    private void OnMouseExit()
    {
        transform.GetComponent<Renderer>().material = normalMat;
    }
}

