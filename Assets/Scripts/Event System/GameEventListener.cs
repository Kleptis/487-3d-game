using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class CustomGameEvent : UnityEvent<Component, object> { }
public class GameEventListener : MonoBehaviour
{
#pragma warning disable 649
    [Tooltip("Event to register with.")]
    public GameEvent gameEvent;

    [Tooltip("Response to invoke when Event with GameData is raised.")]
    public CustomGameEvent response;

    //public UnityEvent response;
    //allows you to link method calls directly in the editor

    private void OnEnable()
    {
        gameEvent.Register(this);
    }
    private void OnDisable()
    {
        gameEvent.Deregister(this);
    }
    public void OnEventRaised(Component sender, object data)//Called by the game event when an event is broadcast
    {
        response.Invoke(sender, data);
    }
}
