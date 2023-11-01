using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Merchant : MonoBehaviour
{
    public float _time;
    [SerializeField] private float _timer;
    [SerializeField] private GameObject _window;
    [SerializeField] private Button _exit;

    void OnEnable()
    {
        _exit.onClick.AddListener(CloseShop);
    }

    void OnDisable()
    {
        _exit.onClick.RemoveAllListeners();
    }

    void Update()
    {
        _time += Time.deltaTime;

        if(_time >= _timer)
        OpenShop();
    }

    private void OpenShop()
    {
        if(_window.activeSelf == false)
        {
            Time.timeScale = 0;
            _time = 0;
            _window.SetActive(true);
        }
    }

    private void CloseShop()
    {
        Time.timeScale = 1;
        _window.SetActive(false);   
    }
}
