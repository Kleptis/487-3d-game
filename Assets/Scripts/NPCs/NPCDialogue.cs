using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//purpose is to pass all values to dialogue panel
//every time continue is hit it will pass name, dialogue,
//and a picture to the DialoguePanel Class
public class NPCDialogue : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    NPCBase npcBase;
    [SerializeField] GameObject npc;
    [Header("Events")]
    public GameEvent talking;
    private int id;
    private Story currentStory;
    private bool dialogueIsPlaying;
    //first check to see if you can access charImage and Name from sender
    private object[] array = new object[3];
    private void Awake()
    {
        npcBase = npc.GetComponent<NPCBase>();
        array[0] = npcBase.CharImage;
        array[1] = npcBase.Name;
        id = -1111;
    }
    private void Start()
    {
        dialogueIsPlaying = false;
        currentStory = new Story(inkJSON.text);
    }
    //public void sendText(Component sender, object data)
    public void sendText()
    {
        if (npcBase.Id == id)
        {
            dialogueIsPlaying = true;
            ContinueStory();
        }
    }
    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            array[2] = currentStory.Continue();
            Debug.Log(array[2]);
            talking.Raise(this, array);
        }
        else
        {
            array[2] = null;
            talking.Raise(this, array);
        }
    }

    public void giveMeId(Component sender, object data)
    {
        id = (int)data;
        //Debug.Log(id);
    }

}
