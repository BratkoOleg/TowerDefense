using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TowerGun : MonoBehaviour
{
    private GameObject[] _enemys;
    private GameObject _nearest;
    private float _timer;
    private bool _startedSkillBonus = false;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _weaponDir;
    [SerializeField] private float _reload = 1f;

    private float _speedRotate = 10f;
    public int rotationOffset = -90;
    private float rotZ;
 
    void Update()
    {
        if(SetNearestEnemy() != null)
        {
            Vector3 difference = SetNearestEnemy().transform.position - transform.position;
            rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
            
            Quaternion rotation = Quaternion.AngleAxis (rotZ + rotationOffset, Vector3.forward);
            transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * _speedRotate);
        }

        if(_startedSkillBonus == true && _timer >= 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _startedSkillBonus = false;
            _reload = 1f;
        }
    }

    void OnEnable()
    {
        EventBus.Instance.Skill1WasUsed += OnChangedShootSpeed;
    }

    void OnDisable()
    {
        EventBus.Instance.Skill1WasUsed -= OnChangedShootSpeed;
    }

    void Awake()
    {
        StartCoroutine(ReloadGun());
    }

    // void Update()
    // {
    //     SetRotationGun(SetNearestEnemy());
        
    //     if(_startedSkillBonus == true && _timer >= 0)
    //     {
    //         _timer -= Time.deltaTime;
    //     }
    //     else
    //     {
    //         _startedSkillBonus = false;
    //         _reload = 1f;
    //     }
    // }

    private IEnumerator ReloadGun()
    {
        while(true)
        {
            Instantiate(_bulletPrefab, this._weaponDir.position, transform.rotation);
            yield return new WaitForSeconds(_reload);
        }
    }

    // private void SetRotationGun(GameObject enemy)
    // {
    //     if(enemy != null)
    //     this.gameObject.transform.rotation = Quaternion.LookRotation(transform.position, enemy.transform.position);
    // }

    private GameObject SetNearestEnemy()
    {
        _enemys = GameObject.FindGameObjectsWithTag("Enemy");
        float dis = Mathf.Infinity;
        Vector3 pos = this.gameObject.transform.position;

        foreach (GameObject enemy in _enemys)
        {
            Vector3 diffPos = enemy.transform.position - pos;
            float curDis = diffPos.sqrMagnitude;
            if(curDis < dis)
            {
                _nearest = enemy;
                dis = curDis;
            }
        }
        return _nearest;
    }

    private void OnChangedShootSpeed(float workTime)
    {
        _startedSkillBonus = true;
        _reload = _reload * 0.5f;
        _timer = workTime;
    }
}
