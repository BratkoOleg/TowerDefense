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

    public Action<int, int> ChangedExp;
    public Action<int> LeveledUp;

    public Action<float, string> TriedToUseSkill;
    public Action<string> UsedSkill;
    public Action<float, string> GotReloadSkill;
    public Action<string> FinishedReloadSkill;

    public Action<float> Skill1WasUsed;
    public Action<float> Skill2WasUsed;
}