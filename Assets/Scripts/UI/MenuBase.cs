using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBase : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject menuPanel;
    private int click_count;
    void Start()
    {
        click_count = 0;
        menuPanel.SetActive(false);
    }

    public void show_and_hide_panel()
    {
        //Debug.Log(pausePanel.activeInHierarchy);
        if (click_count == 0)
        {
            Time.timeScale = 0f;
            showpanel();

        }
        else if (menuPanel.activeInHierarchy == true && click_count != 0)
        {
            Time.timeScale = 1f;
            hidepanel();
        }
    }
    public void showpanel()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
        click_count++;
        click_count %= 2;
    }
    public void hidepanel()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
        click_count++;
        click_count %= 2;
    }
}
