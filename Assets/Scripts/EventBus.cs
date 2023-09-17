using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EventBus
{
    private EventBus() {}

    private static EventBus _eventBus;
    public static EventBus Instance
    {
        get
        {
            if(_eventBus == null)
                _eventBus = new EventBus();
            return _eventBus;
        }
    }
    
    public Action TowerAttacked;
    public Action<int> EarnedFromEnemy;
    public Action<int> ExpFromEnemy;
}