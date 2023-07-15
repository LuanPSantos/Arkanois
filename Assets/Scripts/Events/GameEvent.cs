using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();
    private static long traceId = 0;

    public void Raise()
    {
        traceId++;
        Debug.Log("=> Raise: " + name + ", traceId="+ traceId);
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(traceId);
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