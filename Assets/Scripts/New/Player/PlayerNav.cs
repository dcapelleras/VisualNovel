using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNav : MonoBehaviour //player
{
    #region References
    public NavMeshAgent agent;
    Camera cam;
    #endregion
    public bool inInventory;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (inInventory)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);

            }
        }
    }
}
