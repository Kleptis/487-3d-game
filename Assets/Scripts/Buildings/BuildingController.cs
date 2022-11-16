using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    private void Start()
    {
        GameEvents.current.onBuildingTriggerEnter += OnBuildingInteracted;
        GameEvents.current.onBuildingTriggerExit += OnBuildingExit;
    }

    // Update is called once per frame
    private void OnBuildingInteracted(int id)
    {
        if(id == this.id)
        {
            Debug.Log("you're interacting with building #" + id);
        }

        if (this.id == 2 && this.id == id)
        {
            if (Input.GetKeyDown("space"))
            {
                print("space key was pressed");
            }
            if (GameManager.redherb == 1)
            {
                GameManager.redherb--;
                GameManager.damagerange++;

            }
            
        }
    }
    private void OnBuildingExit(int id)
    {
        if(id == this.id)
        {
            Debug.Log("you're exiting building #" + id);
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onBuildingTriggerEnter -= OnBuildingInteracted;
        GameEvents.current.onBuildingTriggerExit -= OnBuildingExit;
    }
}
