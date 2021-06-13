using System;
using System.Collections.Generic;
using DefaultNamespace;

public static class EventBus
{
    private static Dictionary<Type, List<IGlobalSubscriber>> _subscribers =
        new Dictionary<Type, List<IGlobalSubscriber>>();

    public static void Publish<TSubscriber>(Action<TSubscriber> action) where TSubscriber : IGlobalSubscriber
    {
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        
        var subscribers = _subscribers[typeof(TSubscriber)];

        foreach (var globalSubscriber in subscribers)
        {
            action.Invoke(globalSubscriber is TSubscriber subscriber ? subscriber : default);
        }
    }
        
    public static void Subscribe<TSubscriber>(TSubscriber globalSubscriber) where TSubscriber : IGlobalSubscriber
    {
        if (globalSubscriber == null)
        {
            throw new ArgumentNullException(nameof(globalSubscriber));
        }
        
        var globalSubscriberType = GetSubscribersTypes(globalSubscriber);
            
        foreach (var type in globalSubscriberType)
        {
            if (!_subscribers.ContainsKey(type))
            {
                _subscribers.Add(type, new List<IGlobalSubscriber>());
            }

            _subscribers[type].Add(globalSubscriber);
        }
    }
        
    public static void Unsubscribe<TSubscriber>(TSubscriber globalSubscriber) where TSubscriber : IGlobalSubscriber
    {
        if (globalSubscriber == null)
        {
            throw new ArgumentNullException(nameof(globalSubscriber));
        }
        
        var subscriberTypes = GetSubscribersTypes(globalSubscriber);
            
        foreach (var type in subscriberTypes)
        {
            if (_subscribers.ContainsKey(type))
            {
                _subscribers[type].Remove(globalSubscriber);
            }
        }
    }

    private static List<Type> GetSubscribersTypes(IGlobalSubscriber globalSubscriber)
    {
        var typeGlobalSubscriber = globalSubscriber.GetType();
        var subscriberTypes = new List<Type>();
            
        foreach (var typeInterface in typeGlobalSubscriber.GetInterfaces())
        {
            if (typeof(IGlobalSubscriber).IsAssignableFrom(typeInterface) && typeInterface != typeof(IGlobalSubscriber))
            {
                subscriberTypes.Add(typeInterface);
            }
        }

        return subscriberTypes;
            
    }
}