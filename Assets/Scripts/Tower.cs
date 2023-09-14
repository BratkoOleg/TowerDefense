using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("got damage");
            EventBus.Instance.TowerAttacked?.Invoke();
            Destroy(other.gameObject);
        }
    }
}
