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
        if (transform.position != goalPosition)
        {
            Debug.Log("Moving");
            transform.Translate(transform.position + goalPosition * moveSpeed * Time.deltaTime);
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
                if (TryGetComponent(out DemoInteractable interactable))
                {
                    interactable.Interact();
                    goalPosition = interactable.moveToPosition.position;
                    goalPosition.y += 2.7f;
                    
                }
            }
        }
    }
}
