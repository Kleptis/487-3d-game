using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Kanji
{
    public string kanji;
    public int grade;
    public int stroke_count;
    public string[] meanings;
    public string[] kun_readings;
    //public string[] on_readings;
    //public string[] name_readings;
    //public int jlpt;
    //public string unicode;
    //public string heisig_en;
    //    {
    //  "kanji": "蛍",
    //  "grade": 8,
    //  "stroke_count": 11,
    //  "meanings": [
    //    "lightning-bug",
    //    "firefly"
    //  ],
    //  "kun_readings": [
    //    "ほたる"
    //  ],
    //  "on_readings": [
    //    "ケイ"
    //  ],
    //  "name_readings": [],
    //  "jlpt": 1,
    //  "unicode": "86cd",
    //  "heisig_en": "lightning-bug"
    //}

    //public string[] categories;
    //public string created_at;
    //public string icon_url;
    //public string id;
    //public string updated_at;
    //public string url;
    //public string value;


    //{"categories":[],
    //"created_at":"2020-01-05 13:42:26.447675",
    //"icon_url":"https://assets.chucknorris.host/img/avatar/chuck-norris.png",
    //"id":"RjbTEK-KSmqQGzzl8VuWtA",
    //"updated_at":"2020-01-05 13:42:26.447675",
    //"url":"https://api.chucknorris.io/jokes/RjbTEK-KSmqQGzzl8VuWtA",
    //"value":"Chuck Norris was hunting bears when his rifle jammed.
    //Faced with a charging Grizzly, Chuck grabbed a rubber band from his pocket
    //and strangled the bear."}
}
