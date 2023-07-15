using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent response;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this); 
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this); 
    }

    public void OnEventRaised(long traceId)
    {
        Debug.Log("=> Listener: " + name + ", traceId=" + traceId);
        response.Invoke(); 
    }
}
