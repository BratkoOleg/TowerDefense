using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector2 _target = Vector2.zero;
    [SerializeField] private float _speed;
    public int _maxHP = 2;
    public int _coins = 1;
    [SerializeField] private int _exp = 1;
    [SerializeField] int _curHP;
    [SerializeField] Image _image;
    private GameObject[] _players;
    private GameObject _nearest;
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
        transform.position = Vector2.MoveTowards(transform.position, SetNearestPlayer().transform.position, step);
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

    private GameObject SetNearestPlayer()
    {
        _players = GameObject.FindGameObjectsWithTag("Player");
        float dis = Mathf.Infinity;
        Vector3 pos = this.gameObject.transform.position;

        foreach (GameObject enemy in _players)
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
