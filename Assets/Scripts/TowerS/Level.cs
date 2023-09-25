using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Text _levelText;
    [SerializeField] private Text _xpNeed;

    void OnEnable()
    {
        EventBus.Instance.LeveledUp += OnLevelChanged;
        EventBus.Instance.ChangedExp += OnExpChanged;
    }

    void OnDisable()
    {
        EventBus.Instance.LeveledUp -= OnLevelChanged;
        EventBus.Instance.ChangedExp -= OnExpChanged;
    }

    private void OnExpChanged(int curXp, int maxXP)
    {
        _xpNeed.text = curXp + "/" + maxXP;
    }

    private void OnLevelChanged(int level)
    {
        _levelText.text = "" + level;
    }
}
