using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector2 _target = Vector2.zero;
    [SerializeField] float _speed;
    [SerializeField] int _hp = 1;
    [SerializeField] int _coins = 1;

    void OnDisable()
    {
        EventBus.Instance.EarnedFromEnemy?.Invoke(_coins);
    }

    void Update()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _target, step);
    }
}
