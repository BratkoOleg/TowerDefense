using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSupTower : MonoBehaviour
{
    [SerializeField] private Button _openMenu;
    [SerializeField] private Button _upgradeGun;
    [SerializeField] private Button _upgradeHP;
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
        _upgradeGun.onClick.AddListener(UpgradeGun);
        _upgradeHP.onClick.AddListener(UpgradeHP);
        _destroy.onClick.AddListener(Destroy);
        _exit.onClick.AddListener(CloseMenu);
    }

    void OnDisable()
    {
        _openMenu.onClick.RemoveAllListeners();
        _upgradeGun.onClick.RemoveAllListeners();
        _destroy.onClick.RemoveAllListeners();
        _exit.onClick.RemoveAllListeners();
        _upgradeHP.onClick.RemoveAllListeners();
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

    private void UpgradeHP()
    {

    }

    private void UpgradeGun()
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
        BuildTower._amountTowers--;
        Destroy(gameObject);
    }

    private void SetText(int coins)
    {
        _cost.text = "" + coins;
    }
}
