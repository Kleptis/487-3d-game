using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_to_xaviers_scene : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Events")]
    public GameEvent fightStart;

    public void OnCollisionEnter2d(Collider2D collision)
    {
        Debug.Log("Trigger");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hi");
            //fightStart.Raise();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
