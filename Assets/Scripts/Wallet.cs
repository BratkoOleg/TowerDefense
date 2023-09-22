using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    [SerializeField] Text _wallet;
    [SerializeField] int _coinsAmount = 0;

    void OnEnable()
    {
        EventBus.Instance.EarnedFromEnemy += OnEarnedFromEnemy;
    }

    void OnDisable()
    {
        EventBus.Instance.EarnedFromEnemy -= OnEarnedFromEnemy;
    }

    void Awake()
    {
        _wallet = GetComponent<Text>();
    }

    private void OnEarnedFromEnemy(int coins)
    {
        _coinsAmount += coins;
        _wallet.text = "" + _coinsAmount;
    }
}
