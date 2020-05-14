using UnityEngine;

public class Vector3GameEventListener : GameEventListener
{
    public Vector3GameEvent Vector3GameEvent;

    public Vector3UnityEvent Response;

    protected override GameEvent Event => Vector3GameEvent;

    public override void OnEventRaised(params object[] parameters)
    {
        Response.Invoke((Vector3)parameters[0]);
    }
}