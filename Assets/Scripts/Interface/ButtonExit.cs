using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonExit : MonoBehaviour
{
    [SerializeField] private Button _button;

    void OnEnable()
    {
        _button.onClick.AddListener(Exit);
    }

    void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
