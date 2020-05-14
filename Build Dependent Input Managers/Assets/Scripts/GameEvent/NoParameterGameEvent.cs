using System;
using UnityEngine;

[CreateAssetMenu]
public class NoParameterGameEvent : GameEvent
{
    protected override Type[] ExpectedParameterTypes => null;

    protected override void OverriddenRaise(params object[] parameters)
    {
        for (var i = GameEventListeners.Count - 1; i >= 0; i--)
            GameEventListeners[i].OnEventRaised(parameters);
    }
}