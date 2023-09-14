using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealthBar : MonoBehaviour
{
    [SerializeField] Slider _slider;
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
        _slider = GetComponent<Slider>();
        _currentHP = _maxHP;
    }

    private void OnTowerAttacked()
    {
        _currentHP--;
        _slider.value -= (float)1 / _currentHP;
    }
}
