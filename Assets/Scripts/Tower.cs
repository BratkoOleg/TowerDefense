using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int _level;

    void OnEnable()
    {
        EventBus.Instance.LeveledUp += OnLevelChanged;
    }

    void OnDisable()
    {
        EventBus.Instance.LeveledUp -= OnLevelChanged;
    }

    private void OnLevelChanged(int level)
    {
        _level = level;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("got damage");
            Destroy(other.gameObject);
            EventBus.Instance.TowerAttacked?.Invoke();
        }
    }
}
