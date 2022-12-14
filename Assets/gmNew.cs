using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gmNew : MonoBehaviour
{
    private const int ENEMY_COUNT = 20;

    // Start is called before the first frame update\
    public static gmNew Instance;
    public static int enemyCount;


    void Awake()
    {
        Instance = this;
    }
    public void enemyKilled()
    {
        enemyCount--;
        Debug.Log(enemyCount);
        if (enemyCount == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    void Start()
    {
        
        enemyCount = ENEMY_COUNT;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
