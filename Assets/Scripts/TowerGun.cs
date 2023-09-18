using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TowerGun : MonoBehaviour
{
    private bool _foundTarget = false;
    private GameObject[] _enemys;
    private GameObject _nearest;
    private float _timer;
    private bool _startedSkillBonus = false;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _weaponDir;
    [SerializeField] private float _reload = 1f;

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

    void Update()
    {
        if(_foundTarget)
        SetRotationGun(SetNearestEnemy());
        
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

    private IEnumerator ReloadGun()
    {
        while(true)
        {
            if(_foundTarget)
            Instantiate(_bulletPrefab, _weaponDir.position, transform.rotation);
            yield return new WaitForSeconds(_reload);
        }
    }

    private void SetRotationGun(GameObject enemy)
    {
        if(enemy != null)
        transform.rotation = Quaternion.LookRotation(Vector3.forward, enemy.transform.position);
    }

    private GameObject SetNearestEnemy()
    {
        _enemys = GameObject.FindGameObjectsWithTag("Enemy");
        float dis = Mathf.Infinity;
        Vector3 pos = transform.position;

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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            SetNearestEnemy();
            _foundTarget = true;
        }
    }

    private void OnChangedShootSpeed(float workTime)
    {
        _startedSkillBonus = true;
        _reload = _reload * 0.5f;
        _timer = workTime;
    }
}
