using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Yarn.Unity;

public class CamManager : MonoBehaviour
{
    public static CamManager instance;

    public List<CinemachineVirtualCamera> cinemachines;

    DialogueRunner dialogueRunner;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        dialogueRunner = FindObjectOfType<DialogueRunner>();
        dialogueRunner.AddCommandHandler<int>("camera", MoveToCam);
    }

    public void MoveToCam(int camIndex)
    {
        for (int i = 0; i < cinemachines.Count; i++)
        {
            if (i != camIndex)
            {
                cinemachines[i].Priority = 9;
            }
            else
            {
                cinemachines[i].Priority = 11;
            }
        }
    }
}
