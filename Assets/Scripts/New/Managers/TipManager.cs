using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipManager : MonoBehaviour
{
    float notMovingCounter;
    public bool notMoving;
    float timeForMovingTime = 10f;
    

    private void Update()
    {
        if (notMoving && notMovingCounter < timeForMovingTime)
        {
            notMovingCounter += Time.deltaTime;
        }
        else
        {
            notMovingCounter = 0;
        }
    }

    public void ShowTip()
    {
        if (notMovingCounter >= timeForMovingTime)
        {

        }
    }
}
