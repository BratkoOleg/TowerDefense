using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSupTower : MonoBehaviour
{
    [SerializeField] private Button _openMenu;
    [SerializeField] private Button _upgrade;
    [SerializeField] private Button _destroy;
    [SerializeField] private Button _exit;
    [SerializeField] private GameObject _menu;
    [SerializeField] int _costUpgrade;
    [SerializeField] private TextMeshProUGUI _cost;
    [SerializeField] private GameObject _gun;

    void OnEnable()
    {
        SetText(_costUpgrade);
        _openMenu.onClick.AddListener(OpenMenu);
        _upgrade.onClick.AddListener(Upgrade);
        _destroy.onClick.AddListener(Destroy);
        _exit.onClick.AddListener(CloseMenu);
    }

    void OnDisable()
    {
        _openMenu.onClick.RemoveAllListeners();
        _upgrade.onClick.RemoveAllListeners();
        _destroy.onClick.RemoveAllListeners();
        _exit.onClick.RemoveAllListeners();
    }

    private void CloseMenu()
    {
        _menu.SetActive(false);
    }

    private void OpenMenu()
    {
        if(BuildTower._buildingMode == false)
        _menu.SetActive(true);
    }

    private void Upgrade()
    {
        if(Wallet._coinsAmount >= _costUpgrade)
        {
            Wallet._coinsAmount -= _costUpgrade;

            GameObject gun = Instantiate(_gun, transform.position, Quaternion.identity);
            gun.transform.SetParent(gameObject.transform);

            _costUpgrade += (int)(_costUpgrade * 0.5f);
            SetText(_costUpgrade);

            Debug.Log("tower was upgraded");
            _menu.SetActive(false);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void SetText(int coins)
    {
        _cost.text = "" + coins;
    }
}
