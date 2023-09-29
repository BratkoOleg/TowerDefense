using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Text _levelText;
    [SerializeField] private Text _xpNeed;
    [SerializeField] private Text _lvlPoints;

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

    void Update()
    {
        _lvlPoints.text = "" + TowerExpBar._lvlPoints;
    }

    private void OnExpChanged(int curXp, int maxXP)
    {
        _xpNeed.text = curXp + "/" + maxXP;
    }

    private void OnLevelChanged(int level)
    {
        _levelText.text = "" + level;
        _lvlPoints.text = "" + TowerExpBar._lvlPoints;
    }
}
