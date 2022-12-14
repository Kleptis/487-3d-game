using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiObj : Kanji
{
    // Start is called before the first frame update
    [SerializeField] private MeshFilter modelYouWantToChange;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMesh(Component sender, object data)
    {
        MeshFilter model = (MeshFilter)data;
        modelYouWantToChange = model;
    }
}
