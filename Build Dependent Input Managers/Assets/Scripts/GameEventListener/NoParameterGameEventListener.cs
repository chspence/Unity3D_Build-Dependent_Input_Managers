using UnityEngine.Events;

public class NoParameterGameEventListener : GameEventListener
{
    public NoParameterGameEvent NoParameterGameEvent;

    public UnityEvent Response;

    protected override GameEvent Event => NoParameterGameEvent;

    public override void OnEventRaised(params object[] parameters)
    {
        Response.Invoke();
    }
}