using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector2 _target = Vector2.zero;
    [SerializeField] private float _speed;
    [SerializeField] private int _maxHP = 2;
    [SerializeField] private int _coins = 1;
    [SerializeField] private int _exp = 1;
    [SerializeField] int _curHP;
    [SerializeField] Image _image;
    public int _damage = 1;

    void Awake()
    {
        _curHP = _maxHP;
    }

    void OnDisable()
    {
        EventBus.Instance.EarnedFromEnemy?.Invoke(_coins);
        EventBus.Instance.ExpFromEnemy?.Invoke(_exp);
    }

    void Update()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _target, step);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Debug.Log("enemy got damage");
            int bulletDamage = other.gameObject.GetComponent<Bullet>().bulletDamage;
            OnHealthChanged(bulletDamage);
        }
    }

    private void OnHealthChanged(int damage)
    {
        _curHP -= damage;
        if(_curHP <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            float curHpInPercent = (float)_curHP / _maxHP;
            _image.fillAmount = curHpInPercent;
        }
    }
}
