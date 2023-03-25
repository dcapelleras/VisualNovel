using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;

    [SerializeField] GameObject loadingScreen;
    
    public float loadingScreenTime = 5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeLoadingScreen()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(UnloadLoadingScreen());
    }

    IEnumerator UnloadLoadingScreen()
    {
        yield return new WaitForSeconds(loadingScreenTime);
        loadingScreen.SetActive(false);
    }
}
