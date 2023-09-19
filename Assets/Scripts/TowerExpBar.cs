using UnityEngine;
using UnityEngine.UI;

public class TowerExpBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    private int _level;
    private int _maxXP = 10;
    private int _curXP;

    void OnEnable()
    {
        EventBus.Instance.ExpFromEnemy += OnExpChanged;
        _maxXP = 10;
        _curXP = 0;
    }

    void OnDisable()
    {
        EventBus.Instance.ExpFromEnemy += OnExpChanged;
    }

    private void OnExpChanged(int exp)
    {
        _curXP += exp;
        float curXpInPercent = (float)_curXP / _maxXP;
        if(_image != null)
        _image.fillAmount = curXpInPercent;

        if(_image.fillAmount >= 1)
        {
            _curXP = 0;
            _image.fillAmount = 0;
            _level++;
            float nextMaxXp = (float)_maxXP * 0.5f; 
            _maxXP += (int)nextMaxXp;
            EventBus.Instance.LeveledUp?.Invoke(_level);
        }
        
        EventBus.Instance.ChangedExp?.Invoke(_curXP, _maxXP);
    }
}
