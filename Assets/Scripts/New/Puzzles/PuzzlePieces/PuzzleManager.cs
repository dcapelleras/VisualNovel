using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public int partsToComplete;
    int partsCompleted;

    public void CheckParts()
    {
        partsCompleted++;
        if (partsCompleted == partsToComplete)
        {
            //puzzle completed
            //teleport to room and trigger endgame dialogue
            PlayerNav player = FindObjectOfType<PlayerNav>();
            player.EndGame();
        }
    }
}
