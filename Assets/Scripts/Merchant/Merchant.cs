using UnityEngine;
using UnityEngine.UI;

public class Merchant : MonoBehaviour
{
    public float _time;
    [SerializeField] private float _timer;
    [SerializeField] private GameObject _window;
    [SerializeField] private Button _exit;
    [SerializeField] private Transform _ShopCurSkillsParent;
    [SerializeField] private Transform _shopItemsParent;
    [SerializeField] GameObject[] _skillsCanvas;

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

    private void StartShop()
    {
        ShowCurSkills();
        ShowAvailableSkills();
    }

    private void ShowAvailableSkills()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject skill = Instantiate(_skillsCanvas[Random.Range(0,_skillsCanvas.Length)], Vector3.zero, Quaternion.identity);
            skill.transform.SetParent(_shopItemsParent);
        }
    }

    private void ShowCurSkills()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject skill = Instantiate(RollSkills._rolledSkillsForShop[i], Vector3.zero, Quaternion.identity);
            skill.transform.SetParent(_ShopCurSkillsParent);
        }
    }

    private void OpenShop()
    {
        if(_window.activeSelf == false)
        {
            Time.timeScale = 0;
            _time = 0;
            _window.SetActive(true);
            StartShop();
        }
    }

    private void CloseShop()
    {
        if(_ShopCurSkillsParent.childCount != 0)
        {
            for (int i = 0; i < _ShopCurSkillsParent.childCount; i++)
            {
                Destroy(_ShopCurSkillsParent.GetChild(i).gameObject);
            }
        }
        if(_shopItemsParent.childCount != 0)
        {
            for (int i = 0; i < _shopItemsParent.childCount; i++)
            {
                Destroy(_shopItemsParent.GetChild(i).gameObject);
            }
        }
        Time.timeScale = 1;
        _window.SetActive(false);   
    }
}
