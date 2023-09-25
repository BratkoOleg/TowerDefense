using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSupTower : MonoBehaviour
{
    [SerializeField] Button _openMenu;
    [SerializeField] Button _upgrade;
    [SerializeField] Button _destroy;
    [SerializeField] GameObject _menu;

    void OnEnable()
    {
        _openMenu.onClick.AddListener(OpenMenu);
        _upgrade.onClick.AddListener(Upgrade);
        _destroy.onClick.AddListener(Destroy);
    }

    void OnDisable()
    {
        _openMenu.onClick.RemoveAllListeners();
        _upgrade.onClick.RemoveAllListeners();
        _destroy.onClick.RemoveAllListeners();
    }

    private void OpenMenu()
    {
        _menu.SetActive(true);
    }

    private void Upgrade()
    {
        Debug.Log("tower was upgraded");
        _menu.SetActive(false);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
