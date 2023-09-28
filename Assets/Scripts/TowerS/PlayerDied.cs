using TMPro;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    [SerializeField] private GameObject _window;
    [SerializeField] private TextMeshProUGUI _coins;
    [SerializeField] private TextMeshProUGUI _kills;
    [SerializeField] private GameObject _gun;
    [SerializeField] private GameObject[] _spawners;

    void OnEnable()
    {
        EventBus.Instance.PlayerDied += OnPlayerDied;
    }

    void OnDisable()
    {
        EventBus.Instance.PlayerDied -= OnPlayerDied;
    }

    private void OnPlayerDied(int kills, int coins)
    {
        _gun.SetActive(false);
        _spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach(GameObject spawner in _spawners)
        {
            spawner.SetActive(false);
        }
        _window.SetActive(true);
        _coins.text = "YOU EARNED: " + coins;
        _kills.text = "YOU KILLED: " + kills;
    }
}
