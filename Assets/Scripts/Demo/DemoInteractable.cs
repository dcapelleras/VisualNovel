using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoInteractable : MonoBehaviour
{
    public Transform moveToPosition;

    public void Interact()
    {
        Debug.Log("You just interacted with " + gameObject.name);
    }
}
