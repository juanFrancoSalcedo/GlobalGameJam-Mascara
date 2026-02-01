using B_Extensions;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : Singleton<EventBus>
{
    private static Dictionary<EventGlobalType,Action> keyValuePairs = new Dictionary<EventGlobalType,Action>();
    public static void Susbscribe(EventGlobalType type, Action action) 
    {
        keyValuePairs.Add(type, action);
        foreach (var item in keyValuePairs) 
        {
            print(item.Key);
        }
    }

    public static void Unsusbscribe(EventGlobalType type)
    {
        //keyValuePairs.Remove(type);
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
