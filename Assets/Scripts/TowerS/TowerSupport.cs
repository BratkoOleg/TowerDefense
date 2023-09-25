using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TowerSupport : MonoBehaviour
{
    [SerializeField] private int _maxHP = 5;
    [SerializeField] int _curHP;
    [SerializeField] Image _image;
    [SerializeField] Tilemap _tilemap;
    [SerializeField] Tile _buildingAvaible;

    void Awake()
    {
        _tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();
        _curHP = _maxHP;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("sup tower got damage");
            int enemyDamage;
            enemyDamage = other.gameObject.GetComponent<Enemy>()._damage;
            OnHealthChanged(enemyDamage);
        }
    }

    void OnDisable()
    {
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
