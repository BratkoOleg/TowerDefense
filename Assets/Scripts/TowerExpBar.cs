using UnityEngine;
using UnityEngine.UI;

public class TowerExpBar : MonoBehaviour
{
    [SerializeField] private Image _image;
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
        _image.fillAmount = curXpInPercent;
    }
}
