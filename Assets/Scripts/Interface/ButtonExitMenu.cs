using UnityEngine;
using UnityEngine.UI;

public class ButtonExitMenu : MonoBehaviour
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
        Application.Quit();
    }
}
