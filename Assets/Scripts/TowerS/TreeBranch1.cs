using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeBranch1 : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private GameObject _shadow;
    [SerializeField] private Button _encreseDMG;
    private bool _bought;

    void OnEnable()
    {
        _encreseDMG.onClick.AddListener(EncreseDMG);
    }

    void OnDisable()
    {
        _encreseDMG.onClick.RemoveAllListeners();
    }

    private void EncreseDMG()
    {
        if(TowerExpBar._lvlPoints >= _cost && _bought == false)
        {
            Debug.Log("spent lvl point");
            TowerExpBar._lvlPoints -= _cost;
            Bullet._increaseDamageFromBranch1 += 1;
            _bought = true;
        }
    }

    void Update()
    {
        if(TowerExpBar._lvlPoints >= _cost && _bought == false)
        {
            _shadow.SetActive(false);
        }
        else
        {
            _shadow.SetActive(true);
        }
    }
}
