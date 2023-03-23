using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject exit;
    bool menuOpen;
    public GameObject inventory;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuOpen)
            {
                Resume();
                menuOpen = false;
                CloseInventory();
            }
            else
            {
                inventory.SetActive(true);
                menuPausa.SetActive(true);
                menuOpen = true;
            }
        }
    }

    public void OpenInventory()
    {
        inventory.SetActive(true);
    }

    public void CloseInventory()
    {
        Player[] players = FindObjectsOfType<Player>();
        foreach (Player p in players)
        {
            p.holdingObject = null;
        }
        inventory.SetActive(false);
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
