using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;//for dealing with http web responses, so need that namespace in there
using System.IO; //need to instantiate string reader to read our response

public static class APIHelper   //this script will have absolutely no bearing on the unity engine whatsoever
{
    public static Kanji GetNewKanji()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://kanjiapi.dev/v1/kanji/蛍");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        return JsonUtility.FromJson<Kanji>(json);
    }
    public static KanjiList GetNewKanjiList()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://kanjiapi.dev/v1/kanji/grade-1");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        return JsonUtility.FromJson<KanjiList>(json);
    }
    


}
