using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject exit;
    bool menuOpen;
    public GameObject inventory;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuOpen)
            {
                Resume();
                menuOpen = false;
            }
            else
            {
                inventory.SetActive(true);
                menuPausa.SetActive(true);
                menuOpen = true;
            }
        }
    }

    public void Resume()
    {
        menuPausa.SetActive(false);
        inventory.SetActive(false);
    }

    public void Exit() 
    { 
        exit.SetActive(true);
    }
}
