using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise()
    {
        Debug.Log("=> Raiser: " + name);
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
            Debug.Log("=> Listener: " + listeners[i].name);
        }
            
    }

    public void RegisterListener(GameEventListener listener)
    { 
        listeners.Add(listener); 
    }

    public void UnregisterListener(GameEventListener listener)
    { 
        listeners.Remove(listener); 
    }
}