using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private float _lifeTime = 0.5f;

    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);

        _lifeTime -= Time.deltaTime;
        if(_lifeTime <= 0)
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
