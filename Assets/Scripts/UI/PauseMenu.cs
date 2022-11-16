using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MenuBase
{
    // Start is called before the first frame update
    public void NewKanji()
    {
        Kanji k2 = APIHelper.GetNewKanji();
        DebugArr(k2.meanings);
        DebugArr(k2.kun_readings);
        //Debug.Log(k.kanjiList);
        //KanjiList k = APIHelper.GetNewKanjiList();
    }
    public void QuitToMainMenu()
    {
        Application.Quit();
    }

    private void DebugArr(string[] arr)
    {
        if(arr == null)
        {
            return;
        }
        for(int i = 0; i < arr.Length; i++)
        {
            Debug.Log(arr[i]);
        }
    }
}
//蛍
