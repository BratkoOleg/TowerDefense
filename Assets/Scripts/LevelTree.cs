using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTree : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _menu;

    void OnEnable()
    {
        _button.onClick.AddListener(SetMenuWindow);
    }

    void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void SetMenuWindow()
    {
        if(_menu.activeSelf == false)
        {
            _menu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _menu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
