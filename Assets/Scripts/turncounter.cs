using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class turncounter : MonoBehaviour
{


    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public enemyone firstwolf;
    public enemyone secondwolf;
    public enemyone thirdwolf;

   
    public TMP_Text banner;
    public healthdisplay enemyhealth;
    // Start is called before the first frame update
    bool ourturn = true;
    bool battlefinished = false;
    int reward;
    void Start()
    {
        GameManager.healedthisturn = false;
        GameManager.currenthealth = GameManager.maxhealth;
        Random.seed = System.DateTime.Now.Millisecond;
        banner.text = "Your turn!";
        spawnenemy();
        
    }


    public void spawnenemy()
    {
        if (GameManager.level <= 5)
        {
            enemy1.SetActive(true);
        }
        else if (GameManager.level <= 8)
        {
            enemy3.SetActive(true);
            enemy2.SetActive(true);
        }
        else
        {
            enemy1.SetActive(true);
            enemy2.SetActive(true);
            enemy3.SetActive(true);
        }



    }


    // Update is called once per frame
    void Update()
    {

    }

    public void enemydefeated()
    {
        if ((enemy1.activeSelf == false || firstwolf.currenthealth <= 0) && (enemy2.activeSelf == false || secondwolf.currenthealth <= 0) && (enemy3.activeSelf == false || thirdwolf.currenthealth <= 0))
        {
            
            battlefinished = true;
            reward = Random.Range(1, 4);

                    banner.text = "Enemy defeated: recieved medicinal herbs!";
                    GameManager.herbs++;
             
        }
    }

    public void lunge()
    {
        if (battlefinished && GameManager.currenthealth <= 0)
        {
        resetmanager();
            SceneManager.LoadScene(0);
    
        }

        if (ourturn && GameManager.currentstamina >= 3)
        {

            GameManager.currentstamina -= 3;
            banner.text = "Opponents turn!";


            if (enemy1.activeSelf == true)
            {
                firstwolf.currenthealth -= Random.Range(GameManager.damagerange-GameManager.damagevariance, GameManager.damagerange+1 );
            }
            else if(enemy2.activeSelf == true)
            {
                 secondwolf.currenthealth -= Random.Range(GameManager.damagerange - GameManager.damagevariance, GameManager.damagerange+1 );
               
            }
            else if (enemy3.activeSelf == true)
            {
                thirdwolf.currenthealth -= Random.Range(GameManager.damagerange - GameManager.damagevariance, GameManager.damagerange+1 );

            }
            ourturn = false;
            if ((enemy1.activeSelf == false||firstwolf.currenthealth<=0) && (enemy2.activeSelf == false || secondwolf.currenthealth <= 0) && (enemy3.activeSelf == false || thirdwolf.currenthealth <= 0))
            {

                enemydefeated();
            }
        }
        else if (GameManager.currentstamina <= 5)
            banner.text = "Not enough stamina";


    }

    public void opponentturn()
    {
        int temp;

        if (battlefinished && GameManager.currenthealth > 0)
        {
            GameManager.currentstamina = GameManager.maxstamina;
            SceneManager.LoadScene(1);
        }
        else if(battlefinished)
        {
            resetmanager();
            SceneManager.LoadScene(0);
        }

        if (!ourturn && enemy1.activeSelf == true )
        {


            banner.text = "Your turn!";
            
            temp = (int)(GameManager.armor * Random.Range(firstwolf.damagerange -2, firstwolf.damagerange+1));
            GameManager.currenthealth -= temp;



        }
        if (!ourturn && enemy2.activeSelf == true)
        {


            banner.text = "Your turn!";
            temp = (int)(GameManager.armor * Random.Range(secondwolf.damagerange - 2, secondwolf.damagerange + 1));
            GameManager.currenthealth -= temp;
     

        }
        if (!ourturn && enemy3.activeSelf == true)
        {


            banner.text = "Your turn!";
            temp = (int)(GameManager.armor * Random.Range(thirdwolf.damagerange - 2, thirdwolf.damagerange + 1));
            GameManager.currenthealth -= temp;

        }


        if (GameManager.currenthealth <= 0)
        {

            lostgame();
        }
        ourturn = true;




    }

    public void lostgame()
    {
        battlefinished = true;
        banner.text = "You Lost!";
    }

    public void resetmanager()
    {
            GameManager.maxhealth = 50;
        GameManager.currenthealth = 50;
        GameManager.maxstamina = 50;
        GameManager.currentstamina = 50;
        GameManager.greenherb = 0;
        GameManager.blueherb = 0;
        GameManager.redherb = 0;
        GameManager.damagerange = 5;
        GameManager.damagevariance = 2;
        GameManager.level = 0;
        GameManager.healedthisturn = false;
        GameManager.staminaamount = 10;
        GameManager.armor = 1;
 

        GameManager.healable = false;
        GameManager.staminarecoverable = false;
        GameManager.skilllearned = false;
        GameManager.spelllearned = false;

        GameManager.herbs = 0;
        GameManager.numbercured = 0;


    }

    public void slash()
    {
        if (battlefinished && GameManager.currenthealth <= 0)
        {
            resetmanager();
            SceneManager.LoadScene(0);
      
        }

        if (ourturn && GameManager.currentstamina >= 5)
        {

            GameManager.currentstamina -= 5;
            banner.text = "Opponents turn!";


            if (enemy1.activeSelf == true)
            {
                firstwolf.currenthealth -= Random.Range(GameManager.damagerange - GameManager.damagevariance-2, GameManager.damagerange -1);
            }
            if (enemy2.activeSelf == true)
            {
                secondwolf.currenthealth -= Random.Range(GameManager.damagerange - GameManager.damagevariance-2, GameManager.damagerange -1);

            }
            if (enemy3.activeSelf == true)
            {
                thirdwolf.currenthealth -= Random.Range(GameManager.damagerange - GameManager.damagevariance-2, GameManager.damagerange -1);

            }
            ourturn = false;
            if ((enemy1.activeSelf == false || firstwolf.currenthealth <= 0) && (enemy2.activeSelf == false || secondwolf.currenthealth <= 0) && (enemy3.activeSelf == false || thirdwolf.currenthealth <= 0))
            {

                enemydefeated();
            }
        }
        else if (GameManager.currentstamina <= 5)
            banner.text = "Not enough stamina";


    }

    public void drinkpotion()
    {
        if (GameManager.healable)
        {
            if (battlefinished && GameManager.currenthealth <= 0)
            {
                resetmanager();
                SceneManager.LoadScene(0);

            }

            if (ourturn && GameManager.healable && !GameManager.healedthisturn)
            {
                banner.text = "Your Health Went Up";
                GameManager.currenthealth += GameManager.healamount;

                GameManager.healedthisturn = true;
            }
            else if (GameManager.healedthisturn)
                banner.text = "No More Potions Left";
        }

    }

    public void eatmeal()
    {

        if (GameManager.staminarecoverable)
        {
            if (battlefinished && GameManager.currenthealth <= 0)
            {
                resetmanager();
                SceneManager.LoadScene(0);

            }

            if (ourturn && GameManager.staminarecoverable && !GameManager.atethisturn)
            {
                banner.text = "Tasted Delicious, Your Stamina Went Up";
                GameManager.currentstamina += GameManager.staminaamount;

                GameManager.atethisturn = true;
            }
            else if (GameManager.atethisturn)
                banner.text = "No More Food Left";

        }
    }

    public void fireball()
    {


        float temp;

        if (GameManager.spelllearned)
        {
            if (battlefinished && GameManager.currenthealth <= 0)
            {
                resetmanager();
                SceneManager.LoadScene(0);

            }

            if (ourturn && GameManager.currentstamina >= 18)
            {

                GameManager.currentstamina -= 18;
                banner.text = "Opponents turn!";
                temp = Random.Range(3 * GameManager.damagerange - 3 * GameManager.damagevariance, 3 * GameManager.damagerange);

                if (enemy1.activeSelf == true)
                {
                    firstwolf.currenthealth -= temp;
                }
                if (enemy2.activeSelf == true)
                {
                    secondwolf.currenthealth -= temp;

                }
                if (enemy3.activeSelf == true)
                {
                    thirdwolf.currenthealth -= temp;

                }
                ourturn = false;
                if ((enemy1.activeSelf == false || firstwolf.currenthealth <= 0) && (enemy2.activeSelf == false || secondwolf.currenthealth <= 0) && (enemy3.activeSelf == false || thirdwolf.currenthealth <= 0))
                {

                    enemydefeated();
                }
            }
            else if (GameManager.currentstamina <= 18)
                banner.text = "Not enough stamina";

        }
    }

    public void thousandstrike()
    {
        float temp;

        if (GameManager.skilllearned)
        {

            if (battlefinished && GameManager.currenthealth <= 0)
            {
                resetmanager();
                SceneManager.LoadScene(0);

            }

            if (ourturn && GameManager.currentstamina >= 20)
            {

                GameManager.currentstamina -= 20;
                banner.text = "Opponents turn!";

                temp = Random.Range(5 * GameManager.damagerange - GameManager.damagevariance, 5 * GameManager.damagerange);

                if (enemy1.activeSelf == true)
                {
                    firstwolf.currenthealth -= temp;
                }
                else if (enemy2.activeSelf == true)
                {
                    secondwolf.currenthealth -= temp;

                }
                else if (enemy3.activeSelf == true)
                {
                    thirdwolf.currenthealth -= temp;

                }
                ourturn = false;
                if ((enemy1.activeSelf == false || firstwolf.currenthealth <= 0) && (enemy2.activeSelf == false || secondwolf.currenthealth <= 0) && (enemy3.activeSelf == false || thirdwolf.currenthealth <= 0))
                {

                    enemydefeated();
                }
            }
            else if (GameManager.currentstamina <= 20)
                banner.text = "Not enough stamina";

        }
    }
}
