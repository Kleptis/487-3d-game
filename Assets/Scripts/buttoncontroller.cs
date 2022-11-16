using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class buttoncontroller : MonoBehaviour
{

    public int ID;
    public string name;
    public TMP_Text words;  
    // Start is called before the first frame update
    void Start()
    {
        switch (ID)
        {
            case 1:
                if(GameManager.healable)
                {
                    words.text = name;
                }
                break;
            case 2:
                if (GameManager.staminarecoverable)
                {
                    words.text = name;
                }
                break;
            case 3:
                if (GameManager.spelllearned)
                {
                    words.text = name;
                }
                break;
            case 4:
                if (GameManager.skilllearned)
                {
                    words.text = name;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
