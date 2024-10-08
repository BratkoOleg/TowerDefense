using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TowerSupport : MonoBehaviour
{
    [SerializeField] private int _maxHP = 5;
    [SerializeField] private int _curHP;
    [SerializeField] private Image _image;
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Tile _buildingAvaible;
    private bool _isAttacking;

    void Awake()
    {
        _tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();
        _curHP = _maxHP;
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

    void OnDisable()
    {
        if(_tilemap != null)
        _tilemap.SetTile(SetPosition(), _buildingAvaible);
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

    private Vector3Int SetPosition()
    {
        Vector3Int pos = _tilemap.WorldToCell(transform.position);
        return pos;
    }
}
