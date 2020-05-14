using UnityEngine;

public abstract class GameEventListener : MonoBehaviour
{
    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    protected abstract GameEvent Event { get; }

    public abstract void OnEventRaised(params object[] parameters);
}