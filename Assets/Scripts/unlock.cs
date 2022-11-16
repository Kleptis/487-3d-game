using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class unlock : MonoBehaviour
{
    public GameObject winUI;
    public GameObject loseUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.level >= 13)
        {
            Time.timeScale = 0;

            loseUI.SetActive(true);
        }

        if (GameManager.numbercured >= 6)
        {
            winUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void credits()
    {
        SceneManager.LoadScene(3);

    }

    public void unlockhealingpotion()
    {
        GameManager.healable = true;
        GameManager.numbercured++;

    }

    public void unlockstaminameal()
    {
        GameManager.staminarecoverable = true;
        GameManager.numbercured++;

    }

    public void unlockarmor()
    {
        GameManager.armor = .8f;
        GameManager.numbercured++;

    }

    public void unlockfireball()
    {
        GameManager.spelllearned = true;
        GameManager.numbercured++;

    }

    public void unlockthousandstrike()
    {
        GameManager.skilllearned = true;
        GameManager.numbercured++;

    }

    public void unlockweapon()
    {
        GameManager.damagerange = 15;
        GameManager.numbercured++;

    }
}
