using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScientist : MonoBehaviour
{
    public GameObject requiredObject;
    public Transform moveToPosition;
    bool missionDone;

    public void CheckObject(List<GameObject> objs)
    {
        for (int i = 0;i < objs.Count; i++)
        {
            if (objs[i] == requiredObject)
            {
                missionDone = true;
                Debug.Log("Felicidades");
                return;
            }
        }
    }
}
