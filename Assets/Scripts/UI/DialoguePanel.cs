using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;

//purpose is just for displaying text
public class DialoguePanel : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI char_name;
    [SerializeField] private GameObject char_img_window;
    private Sprite char_image;
    private object[] array = new object[3];

    void Start()
    {
        char_image = char_img_window.GetComponent<Sprite>();
        dialoguePanel.SetActive(false);
    }
    
    public void EnterDialogueMode(Component sender, object data)
    {
        array = (object[])data;
        if ((string)array[2] != null)
        //if ((string)data != null)
        {
            dialoguePanel.SetActive(true);
            char_image = (Sprite)array[0];
            char_name.text = array[1].ToString();
            dialogueText.text = array[2].ToString();
            Time.timeScale = 0f;
            //dialogueText.text = (string)data;
        }
        else
        {
            ExitDialogueMode();
        }
    }
    private void ExitDialogueMode()
    {
        dialoguePanel.SetActive(false);
        Time.timeScale = 1f;
        dialogueText.text = "";
    }
}
