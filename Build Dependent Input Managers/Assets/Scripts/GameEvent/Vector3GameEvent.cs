using System;
using UnityEngine;

[CreateAssetMenu]
public class Vector3GameEvent : GameEvent
{
    protected override Type[] ExpectedParameterTypes => new [] {typeof(Vector3)};

    protected override void OverriddenRaise(params object[] parameters)
    {
        for (var i = GameEventListeners.Count - 1; i >= 0; i--)
            GameEventListeners[i].OnEventRaised(parameters);
    }
}