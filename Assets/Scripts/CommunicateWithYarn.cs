using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class CommunicateWithYarn : MonoBehaviour
{
    DialogueRunner dialogueRunner;
    [SerializeField] GameObject charPrefab;
    private Dictionary<string, GameObject> characters = new Dictionary<string, GameObject>();
    public List<Transform> locations = new List<Transform>();

    private void Awake()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        dialogueRunner.AddCommandHandler<int>("counter", GetNumber);
        dialogueRunner.AddCommandHandler<string, string>("spawnChar", MoveCharacter);
        characters.Add("cube", charPrefab);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            dialogueRunner.Dialogue.Stop(); //to change node in mid running you first stop it
            dialogueRunner.StartDialogue("SecondConversation"); //to start a new dialogue script
        }
    }

    // Update is called once per frame
    void GetNumber(int i)
    {
        Debug.Log(i);
    }

    void MoveCharacter(string characterName, string locationName)
    {
        GameObject character = characters[characterName];
        Vector3 location = GameObject.Find(locationName).transform.position;
        Instantiate(character).transform.position = location;
    }

    [YarnCommand("something")] //HAS TO BE PUBLIC! HAS TO AFFECT AN OBJECT! MUST CALL IT USING NAME OF GAMEOBJECT
    public void DoSomething(string thing)
    {
        Debug.Log("doing " + thing);
    }



    //to play a specific text node: 
    /*if (player presses SPACE)
    then find the nearest NPC
    get that NPC's dialogue node name
    call DialogueRunner.StartDialogue() with the NPC's dialogue node
    disable player movement*/
}
