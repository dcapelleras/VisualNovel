using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CamCinemachine : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera cinemachine;
    public Cinemachine.CinemachineVirtualCamera cinemachine2;

    public Transform firstCam1Focus;
    public Transform firstCam2Focus;

    Camera cam;
    DialogueRunner dialogueRunner;

    int camUsing = 1;

    [SerializeField] float roomZoom = -40f;
    float objectZoom = -20f;

    [SerializeField] DemoPlayer player1;
    [SerializeField] DemoPlayer player2;

    private void Awake()
    {
        cam = Camera.main;
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        dialogueRunner.AddCommandHandler<int>("camera", CineChange);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CineChange(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CineChange(2);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RayMouse();
        }
    }

    public void CineChange(int camNum)
    {
        if (camNum == 1)
        {
            player1.usingThisCharacter = true;
            player2.usingThisCharacter = false;
            cinemachine.LookAt = firstCam1Focus;
            //cinemachine.Follow = firstCam1Focus;
            cinemachine.Priority = 11;
            cinemachine2.Priority = 10;
            camUsing = 1;
            cinemachine.gameObject.transform.position = new Vector3(cinemachine.gameObject.transform.position.x, cinemachine.gameObject.transform.position.y, roomZoom);
        }
        else if (camNum == 2)
        {
            player1.usingThisCharacter = false;
            player2.usingThisCharacter = true;
            cinemachine2.LookAt = firstCam2Focus;
            //cinemachine2.Follow = firstCam2Focus;
            cinemachine.Priority = 10;
            cinemachine2.Priority = 11;
            camUsing= 2;
            cinemachine2.gameObject.transform.position = new Vector3(cinemachine2.gameObject.transform.position.x, cinemachine2.gameObject.transform.position.y, roomZoom);
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
                if (camUsing == 1)
                {
                    //cinemachine.LookAt = hit.transform;
                    //cinemachine.Follow = hit.transform;
                    //cinemachine.gameObject.transform.position = new Vector3(cinemachine.gameObject.transform.position.x, cinemachine.gameObject.transform.position.y, objectZoom);
                    //if (hit.transform.TryGetComponent(out DemoInteractable interactable))
                    //{
                    //    interactable.Interact();
                    //}
                }
                if (camUsing == 2)
                {
                    //cinemachine2.LookAt= hit.transform;
                    //cinemachine2.Follow = hit.transform;
                    //cinemachine2.gameObject.transform.position = new Vector3(cinemachine2.gameObject.transform.position.x, cinemachine2.gameObject.transform.position.y, objectZoom);
                    //if (hit.transform.TryGetComponent(out DemoInteractable interactable))
                    //{
                    //    interactable.Interact();
                    //}
                }
            }
        }
    }
}
