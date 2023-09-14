using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] _enemys;
    [SerializeField] Vector2[] _directions;
    [SerializeField] float _timerToSpawn = 1f;

    void Awake()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while(true)
        {
            Instantiate(_enemys[Random.Range(0, _enemys.Length)], _directions[Random.Range(0, _directions.Length)],quaternion.identity);
            yield return new WaitForSeconds(_timerToSpawn);
        }
    }
}
