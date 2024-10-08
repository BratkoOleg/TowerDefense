using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    [SerializeField] Text _wallet;
    [SerializeField] public static int _coinsAmount = 0;
    [SerializeField] private int _cheatCoin;

    void OnEnable()
    {
        _coinsAmount += _cheatCoin;
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

    void Update()
    {
        _wallet.text = "" + _coinsAmount;
    }

    private void OnEarnedFromEnemy(int coins)
    {
        _coinsAmount += coins;
        _wallet.text = "" + _coinsAmount;
    }
}
