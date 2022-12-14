using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static int maxhealth = 50;
    public static int currenthealth = 50;
    public static int maxstamina = 50;
    public static int currentstamina = 50;
    public static int greenherb = 0;
    public static int blueherb = 0;
    public static int redherb = 0;
    public static int herbs = 0;

    public static float damagerange = 5;
    public static float damagevariance = 2;

    public static int healamount = 10;
    public static int staminaamount = 10;
    public static float armor = 1;


    public static bool healable = false;

    public static bool healedthisturn = false;
    public static bool atethisturn = false;

    public static bool staminarecoverable = false;

    public static bool skilllearned = false;

    public static bool spelllearned = false;

    public static int level = 0;

    public static int numbercured = 0;


}
