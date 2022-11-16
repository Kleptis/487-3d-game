using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    private void Start()
    {
        GameEvents.current.onPortalTriggerEnter += OnPortalEnter;
        GameEvents.current.onPortalTriggerExit += OnPortalExit;
    }

    // Update is called once per frame
    private void OnPortalEnter(int id)
    {
        if(id == this.id)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnPortalExit(int id)
    {
        if(id == this.id)
        {
            Debug.Log("you're exiting building #" + id);
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onBuildingTriggerEnter -= OnPortalEnter;
        GameEvents.current.onBuildingTriggerExit -= OnPortalExit;
    }
}
