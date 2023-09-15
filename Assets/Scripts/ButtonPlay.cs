using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonPlay : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] string _scene;

    void OnEnable()
    {
        _button.onClick.AddListener(OnPlay);
    }

    void OnDesable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void OnPlay()
    {
        SceneManager.LoadScene(_scene);
    }
}
