using UnityEngine;
using UnityEngine.UI;

public class LevelTree : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Button _encreseDMG;
    [SerializeField] private GameObject _menu;

    void OnEnable()
    {
        _button.onClick.AddListener(SetMenuWindow);
        _encreseDMG.onClick.AddListener(EncreseDMG);
    }

    void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
        _encreseDMG.onClick.RemoveAllListeners();
    }

    private void EncreseDMG()
    {
        if(TowerExpBar._lvlPoints >= 1)
        {
            Debug.Log("spent lvl point");
            TowerExpBar._lvlPoints--;
        }
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
