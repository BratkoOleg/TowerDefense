using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private int _maxHP = 1000;
    [SerializeField] int _curHP;
    [SerializeField] Image _image;
    private bool _startedSkillBonus = false;

    void OnEnable()
    {
        EventBus.Instance.Skill2WasUsed += OnHealUp;
    }

    void OnDisable()
    {
        EventBus.Instance.Skill2WasUsed -= OnHealUp;
    }

    void Awake()
    {
        _curHP = _maxHP;
    }

    private void OnLevelChanged(int level)
    {
        _level = level;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("tower got damage");
            int enemyDamage;
            enemyDamage = other.gameObject.GetComponent<Enemy>()._damage;
            OnHealthChanged(enemyDamage);
        }
    }

    private void OnHealthChanged(int damage)
    {
        _curHP -= damage;
        if(_curHP <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            float curHpInPercent = (float)_curHP / _maxHP;
            _image.fillAmount = curHpInPercent;
        }
    }

    private void OnHealUp()
    {
        float howMuchHeal = (float)_maxHP * 0.3f;
        Debug.Log("healed " + (int)howMuchHeal);
        _curHP += (int)howMuchHeal;
        if(_curHP > _maxHP)
        _curHP = _maxHP;
    }
}
