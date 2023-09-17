using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TowerHealthBar : MonoBehaviour
{
    [SerializeField] Image _imageHPbar;
    [SerializeField] int _maxHP = 5;
    [SerializeField] int _currentHP;

    void OnEnable()
    {
        EventBus.Instance.TowerAttacked += OnTowerAttacked;
    }

    void OnDisable()
    {
        EventBus.Instance.TowerAttacked -= OnTowerAttacked;
    }

    private void Awake()
    {
        _currentHP = _maxHP;
    }

    private void OnTowerAttacked()
    {
        _currentHP--;
        Debug.Log("tower attacked");
        if(_currentHP <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            float curHpInPercent = (float)_currentHP / _maxHP;
            _imageHPbar.fillAmount = curHpInPercent;
        }
    }
}
