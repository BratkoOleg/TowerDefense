using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button _buttonPause;
    [SerializeField] private Button _buttonExit;
    [SerializeField] private Button _buttonContinue;
    [SerializeField] private GameObject _pauseMenu;

    void OnEnable()
    {
        _buttonPause.onClick.AddListener(SetMenuOpen);
        _buttonContinue.onClick.AddListener(Continue);
        _buttonExit.onClick.AddListener(ExitFromApp);
    }

    void OnDisable()
    {
        _buttonPause.onClick.RemoveAllListeners();
        _buttonContinue.onClick.RemoveAllListeners();
        _buttonExit.onClick.RemoveAllListeners();
    }

    private void SetMenuOpen()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    private void ExitFromApp()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Continue()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
