using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    private void Awake()
    {
        current = this;
    }
    public event Action<int> onBuildingTriggerEnter;
    public void BuildingTriggerEnter(int id)
    {
        if(onBuildingTriggerEnter != null)
        {
            onBuildingTriggerEnter(id);
        }
    }
    public event Action<int> onBuildingTriggerExit;
    public void BuildingTriggerExit(int id)
    {
        if (onBuildingTriggerExit != null)
        {
            onBuildingTriggerExit(id);
        }
    }

    public event Action<int> onNPCTriggerEnter;
    public void NPCTriggerEnter(int id)
    {
        if(onNPCTriggerEnter != null)
        {
            onNPCTriggerEnter(id);
        }
    }

    public event Action<int> onNPCTriggerExit;
    public void NPCTriggerExit(int id)
    {
        if (onNPCTriggerExit != null)
        {
            onNPCTriggerExit(id);
        }
    }

    public event Action<int> onPortalTriggerEnter;
    public void PortalTriggerEnter(int id)
    {
        if (onPortalTriggerEnter != null)
            onPortalTriggerEnter(id);
    }

    public event Action<int> onPortalTriggerExit;
    public void PortalTriggerExit(int id)
    {
        if (onPortalTriggerExit != null)
            onPortalTriggerExit(id);
    }
}
