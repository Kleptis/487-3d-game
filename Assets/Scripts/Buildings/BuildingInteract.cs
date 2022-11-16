using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInteract : MonoBehaviour
{
    public int id;
    // Start is called before the first frame update
    [Header("Events")]
    public GameEvent onBuildingInteract;
    private void Awake()
    {
        
    }

    private void OnBuildingInteracted()
    {
        //if(id == this.id)
        //{
        //onBuildingInteract.Raise();     
        Debug.Log("you are interacting with a building");
        //}
    }





}
