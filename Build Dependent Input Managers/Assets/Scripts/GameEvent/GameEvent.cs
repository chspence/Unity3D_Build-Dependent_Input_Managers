using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEvent : ScriptableObject, IGameEvent
{
    protected readonly List<GameEventListener> GameEventListeners = new List<GameEventListener>();

    protected void ValidateParameters(params object[] parameters)
    {
        if (parameters == null)
            throw new ArgumentException($"{GetType()} '{name}' was Raised incorrectly.\n"
                                        + $" Expected parameter array but variable was null.");

        if (parameters.Length != (ExpectedParameterTypes?.Length ?? 0))
            throw new ArgumentException($"{GetType()} '{name}' was Raised incorrectly.\n"
                                        + $"Expected {(ExpectedParameterTypes?.Length ?? 0)} parameter(s) but received {parameters.Length}.");

        if((ExpectedParameterTypes?.Length ?? 0) > 0)
            for (var i = 0; i < parameters.Length; i++)
                if(parameters[i].GetType() != ExpectedParameterTypes[i])
                    throw new ArgumentException($"{GetType()} '{name}' was Raised incorrectly.\n"
                                                + $"Expected parameters[{i}] to be of type {ExpectedParameterTypes[i]} but was {parameters[i].GetType()}.\n"
                                                + $"Change parameters[{i}] to be {ExpectedParameterTypes[i]} or create/use a GameEvent that handles this parameter signature.");
    }

    public void RegisterListener(GameEventListener gameEventListener)
    {
        GameEventListeners.Add(gameEventListener);
    }

    public void UnregisterListener(GameEventListener gameEventListener)
    {
        GameEventListeners.Remove(gameEventListener);
    }

    public void Raise(params object[] parameters)
    {
        ValidateParameters(parameters);

        OverriddenRaise(parameters);
    }

    protected abstract Type[] ExpectedParameterTypes { get; }

    protected abstract void OverriddenRaise(params object[] parameters);
}