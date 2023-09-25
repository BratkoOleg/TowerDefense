using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollSkills : MonoBehaviour
{
    [SerializeField] GameObject[] _skillsCanvas;
    [SerializeField] GameObject[] _skillsGame;
    [SerializeField] GameObject[] _rolledSkills;
    [SerializeField] Transform _parentCanvas;
    [SerializeField] Transform _parentGame;
    [SerializeField] Button _buttronRoll;
    [SerializeField] Button _buttronOk;
    [SerializeField] private Dictionary<GameObject, GameObject> SkillNetwork = new Dictionary<GameObject, GameObject>();

    void OnEnable()
    {
        Time.timeScale = 0;

        SkillNetwork.Add(_skillsCanvas[0], _skillsGame[0]);
        SkillNetwork.Add(_skillsCanvas[1], _skillsGame[1]);
        SkillNetwork.Add(_skillsCanvas[2], _skillsGame[2]);
        
        Roll();
        
        _buttronRoll.onClick.AddListener(Roll);
        _buttronOk.onClick.AddListener(CloseWindow);
    }

    void OnDisable()
    {
        _buttronRoll.onClick.RemoveAllListeners();
        _buttronOk.onClick.RemoveAllListeners();
    }

    private void Roll()
    {
        ClearRolled();
        for (int i = 0; i <= 2; i++)
        {            
            _rolledSkills[i] = _skillsCanvas[Random.Range(0, _skillsCanvas.Length)];
        }
        InstantiateSkills();
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
