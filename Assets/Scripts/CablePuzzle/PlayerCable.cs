using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCable : MonoBehaviour
{
    public GameObject holdingCable;
    [SerializeField] Vector3 offset = new Vector3(0, 1, -1);
    public LayerMask screwLayer;

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (holdingCable!= null)
            {
                RaycastHit hit2;
                if (Physics.Raycast(ray, out hit2, ~screwLayer))
                {
                    holdingCable.transform.position = hit2.point - offset;
                }
            }

            if (Input.GetMouseButton(0))
            {
                if (hit.collider.CompareTag("Cable"))
                {
                    holdingCable = hit.collider.gameObject;
                    holdingCable.transform.SetParent(transform);
                }
                if (holdingCable != null && holdingCable.GetComponent<Cable>().inPlace)
                {
                    holdingCable.transform.SetParent(null);
                    holdingCable = null;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                holdingCable.transform.SetParent(null); 
                holdingCable = null;
            }
        }

        
    }
}
