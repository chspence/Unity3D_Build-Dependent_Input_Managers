using System.Collections.Generic;
using UnityEngine;

public class GameEvent : ScriptableObject
{
    private readonly List<GameEventListener> _gameEventListeners = new List<GameEventListener>();

    public void Raise(params object[] parameters)
    {
        for (var i = _gameEventListeners.Count - 1; i >= 0; i--)
            _gameEventListeners[i].OnEventRaised(parameters);
    }

    public void RegisterListener(GameEventListener gameEventListener)
    {
        _gameEventListeners.Add(gameEventListener);
    }

    public void UnregisterListener(GameEventListener gameEventListener)
    {
        _gameEventListeners.Remove(gameEventListener);
    }
}