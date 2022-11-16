using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvent", fileName = "New Game Event")]
public class GameEvent : ScriptableObject
{
    //public List<GameEventListener> listeners = new List<GameEventListener>();
    HashSet<GameEventListener> listeners = new HashSet<GameEventListener>();
    public void Raise()
    {
        Raise(null, null);
    }

    public void Raise(object data)
    {
        Raise(null, data);
    }

    public void Raise(Component sender)
    {
        Raise(sender, null);
    }
    //Raise event through different methods signatures
    public void Raise(Component sender, object data)
    {
        //for (int i = listeners.Count - 1; i >= 0; i--)
        //for (int i = 0; i < listeners.Count; i++)
        //{
        //    listeners[i].OnEventRaised(sender, data);
        //}
        foreach (var globalEventListener in listeners)
            globalEventListener.OnEventRaised(sender, data);
    }//manage listeners
    //############################################################

    public void Register(GameEventListener gameEventListener) => listeners.Add(gameEventListener);
    public void Deregister(GameEventListener gameEventListener) => listeners.Remove(gameEventListener);


    //public void RegisterListener(GameEventListener listener)
    //{
    //    if (!listeners.Contains(listener))
    //        listeners.Add(listener);
    //}
    //public void UnregisterListener(GameEventListener listener)
    //{
    //    if (listeners.Contains(listener))
    //        listeners.Remove(listener);
    //}
}

