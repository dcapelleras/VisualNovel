using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DemoPlayer : MonoBehaviour
{
    Camera cam;

    public bool usingThisCharacter = true;

    [SerializeField] float moveSpeed = 10f;

    Vector3 goalPosition;

    public List<GameObject> inventoryItems = new List<GameObject>();

    GameObject pickingObject;

    GameObject interactingPerson;


    private void Awake()
    {
        cam = Camera.main;
        goalPosition = transform.position;
    }

    private void Update()
    {
        if (usingThisCharacter)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RayMouse();
            }
        }
        Vector3 stopPosition = new Vector3(goalPosition.x, transform.position.y, goalPosition.z);
        if (Vector3.Distance(transform.position, stopPosition) > 0.1f)
        {
            Vector3 direction = goalPosition - transform.position;
            direction.Normalize();
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
        else if (interactingPerson != null)
        {
            if (interactingPerson.TryGetComponent(out DemoScientist scientist))
            {
                scientist.CheckObject(inventoryItems);
                interactingPerson = null;
            }
        }
        else if (pickingObject != null)
        {
            {
                inventoryItems.Add(pickingObject);
                pickingObject.GetComponent<DemoInteractable>().Disappear();
                pickingObject = null;
            }
        }
    }

    void RayMouse()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                if (hit.transform.TryGetComponent(out DemoInteractable interactable))
                {
                    interactable.Interact();
                    goalPosition = interactable.moveToPosition.position;
                    goalPosition.y += 2.7f;
                    pickingObject = hit.collider.gameObject;
                }
            }
            else if (hit.collider.CompareTag("Scientist"))
            {
                if (hit.collider.TryGetComponent(out DemoScientist scientist))
                {
                    goalPosition = scientist.moveToPosition.position;
                    goalPosition.y += 2.7f;
                    if (inventoryItems.Count > 0)
                    {
                        interactingPerson = scientist.gameObject;
                        
                    }
                    else
                    {
                        Debug.Log("You don't have any items");
                    }
                }
            }
        }
    }
}
