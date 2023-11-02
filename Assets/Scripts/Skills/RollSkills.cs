using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RollSkills : MonoBehaviour
{
    [SerializeField] GameObject[] _skillsCanvas;
    [SerializeField] GameObject[] _skillsGame;
    [SerializeField] GameObject[] _rolledSkills;
    [SerializeField] public static GameObject[] _rolledSkillsForShop = new GameObject[3];
    [SerializeField] Transform _parentCanvas;
    [SerializeField] Transform _parentGame;
    [SerializeField] Button _buttronRoll;
    [SerializeField] Button _buttronOk;
    [SerializeField] private Dictionary<GameObject, GameObject> SkillNetwork = new Dictionary<GameObject, GameObject>();
    [SerializeField] private int _timesRerolled;
    [SerializeField] private int _cost = 0;
    [SerializeField] private TextMeshProUGUI _costText;
    private bool haveDublicates = false;

    void OnEnable()
    {
        Time.timeScale = 0;

        SkillNetwork.Add(_skillsCanvas[0], _skillsGame[0]);
        SkillNetwork.Add(_skillsCanvas[1], _skillsGame[1]);
        SkillNetwork.Add(_skillsCanvas[2], _skillsGame[2]);
        
        Roll();
        
        _buttronRoll.onClick.AddListener(Reroll);
        _buttronOk.onClick.AddListener(CloseWindow);
    }

    void OnDisable()
    {
        _buttronRoll.onClick.RemoveAllListeners();
        _buttronOk.onClick.RemoveAllListeners();
    }

    void Update()
    {
        if(haveDublicates == true)
        {
            Roll();
        }
    }

    private void Roll()
    {
        haveDublicates = false;
        ClearRolled();
        for (int i = 0; i <= 2; i++)
        {            
            _rolledSkills[i] = _skillsCanvas[Random.Range(0, _skillsCanvas.Length)];
            _rolledSkillsForShop[i] = _rolledSkills[i];
        }
        for (int i = 0; i < _rolledSkills.Length; i++)
        {
            for (int j = i + 1; j < _rolledSkills.Length; j++)
            {
                if(_rolledSkills[i] == _rolledSkills[j])
                {
                    haveDublicates = true;
                }
                else
                {
                    continue;
                }
            }
        }
        InstantiateSkills();
    }

    private void Reroll()
    {
        if(Wallet._coinsAmount >= _cost)
        {
            _timesRerolled++;
            _cost++;
            _cost *= _timesRerolled;
            _costText.text = "" + _cost;
            Roll();
        }
    }

    private void ClearRolled()
    {
        for (int i = 0; i < _rolledSkills.Length; i++)
        {
            _rolledSkills[i] = null;
        }
        for (int i = 0; i < _parentCanvas.childCount; i++)
        {
            Destroy(_parentCanvas.GetChild(i).gameObject);   
        }
        for (int i = 0; i < _parentGame.childCount; i++)
        {
            Destroy(_parentGame.GetChild(i).gameObject);   
        }
    }   

    private void InstantiateSkills()
    {
        for (int i = 0; i < _rolledSkills.Length; i++)
        {
            GameObject skill = Instantiate(_rolledSkills[i], Vector3.zero, Quaternion.identity);
            skill.transform.SetParent(_parentCanvas);

            GameObject skillGame = Instantiate(SkillNetwork[_rolledSkills[i]], Vector3.zero, Quaternion.identity);
            skillGame.transform.SetParent(_parentGame);
        }
    }

    private void CloseWindow()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
