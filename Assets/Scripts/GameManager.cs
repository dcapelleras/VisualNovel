using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject exit;
    bool menuOpen;

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
                menuPausa.SetActive(true);
                menuOpen = true;
            }
        }
    }

    public void Resume()
    {
        menuPausa.SetActive(false);
    }

    public void Exit() 
    { 
        exit.SetActive(true);
    }
}
