using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    //make the player able to interact with interactable puzzles if holding the right object
    GameObject holdingObject;
    GameObject closestInteractale;
    float minInteractDistance = 2f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (holdingObject) //requires a script to pick up objects
            {
                if (FindClosestInteractable().TryGetComponent(out InteractablePuzzle puzzle))
                {
                    puzzle.Interact(holdingObject.name);
                }
            }
        }
    }

    GameObject FindClosestInteractable()
    {
        GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");
        GameObject closest = null;
        float distance = minInteractDistance;
        for (int i = 0; i < interactables.Length; i++)
        {
            if ((interactables[i].transform.position - transform.position).magnitude < distance)
            {
                closest= interactables[i];
            }
        }
        return closest;
    }
}
