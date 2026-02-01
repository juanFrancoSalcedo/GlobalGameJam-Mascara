using B_Extensions;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : Singleton<EventBus>
{
    private Dictionary<EventGlobalType,Action> keyValuePairs = new Dictionary<EventGlobalType,Action>();


    public void Susbscribe(EventGlobalType type, Action action) 
    {
        if(!keyValuePairs.ContainsKey(type))
            keyValuePairs.Add(type, action);

    }

    public void Unsusbscribe(EventGlobalType type)
    {
        keyValuePairs.Remove(type);
    }

    public void Invoke(EventGlobalType type) 
    {
        keyValuePairs[type].Invoke();
    }

    internal void PositionPlayer(Vector2 lastPosition, Vector2 firstPosition)
    {
        
    }
}
public enum EventGlobalType 
{
    Lost,
    Win
}
