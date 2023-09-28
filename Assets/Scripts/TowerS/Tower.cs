using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private int _maxHP = 1000;
    [SerializeField] int _curHP;
    [SerializeField] Image _image;
    private int _kills, _coins;
    private bool _isAttacking;

    void OnEnable()
    {
        EventBus.Instance.Skill2WasUsed += OnHealUp;
        EventBus.Instance.EarnedFromEnemy += Summary;
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
            _isAttacking = true;
            StartCoroutine(AttackingTower(enemyDamage));
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            _isAttacking = false;
        }
    }

    private IEnumerator AttackingTower(int damage)
    {
        while(_isAttacking)
        {
            Debug.Log("ATTACKEDs");
            OnHealthChanged(damage);
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnHealthChanged(int damage)
    {
        _curHP -= damage;
        if(_curHP <= 0)
        {
            EventBus.Instance.PlayerDied?.Invoke(_kills, _coins);
        }
        else
        {
            float curHpInPercent = (float)_curHP / _maxHP;
            _image.fillAmount = curHpInPercent;
        }
    }

    private void Summary(int coins)
    {
        _coins += coins;
        _kills++;
    }

    private void OnHealUp()
    {
        float howMuchHeal = (float)_maxHP * 0.3f;
        Debug.Log("healed " + (int)howMuchHeal);
        _curHP += (int)howMuchHeal;
        if(_curHP > _maxHP)
        _curHP = _maxHP;
        _image.fillAmount = (float)_curHP / _maxHP;
    }
}
