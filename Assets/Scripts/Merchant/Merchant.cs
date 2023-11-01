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
    [SerializeField] private Transform _skillsParent;
    [SerializeField] private Transform _ShopCurSkillsParent;
    [SerializeField] GameObject[] _skillsCanvas;
    [SerializeField] GameObject[] _skillsGame;
    [SerializeField] private Dictionary<GameObject, GameObject> SkillNetwork = new Dictionary<GameObject, GameObject>();

    void OnEnable()
    {
        SkillNetwork.Add(_skillsCanvas[0], _skillsGame[0]);
        SkillNetwork.Add(_skillsCanvas[1], _skillsGame[1]);
        SkillNetwork.Add(_skillsCanvas[2], _skillsGame[2]);

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
        // for (int i = 0; i < _skillsParent.childCount; i++)
        // {
        //     _skillsGame[i] = _skillsParent.GetChild(i).gameObject;
        // }
        ShowCurSkills();
    }

    private void ShowCurSkills()
    {
        for (int i = 0; i < _skillsGame.Length; i++)
        {
            GameObject skill = Instantiate(_skillsGame[i], Vector3.zero, Quaternion.identity);
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
        Time.timeScale = 1;
        _window.SetActive(false);   
    }
}
