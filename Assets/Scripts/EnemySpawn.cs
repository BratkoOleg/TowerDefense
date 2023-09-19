using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] _enemys;
    [SerializeField] Vector2[] _directions;
    [SerializeField] float _timerToSpawn = 1f;
    [SerializeField] private GameObject _enemySpawner;
    [SerializeField] private float _time;
    private bool _spawnedSpawner = false;

    void Awake()
    {
        StartCoroutine(Spawner());
    }

    void Update()
    {
        _time += Time.deltaTime;

        if(_time >= 120 && _spawnedSpawner == false)
        {
            SpawnSpawner();
        }
    }

    private IEnumerator Spawner()
    {
        while(_time <= 30)
        {
            Instantiate(0);
            yield return new WaitForSeconds(_timerToSpawn);
        }

        while(_time >= 30 && _time <= 60)
        {
            Instantiate(1);
            yield return new WaitForSeconds(_timerToSpawn);
        }

        while(_time >= 60 && _time <= 90)
        {
            Instantiate(2);
            yield return new WaitForSeconds(_timerToSpawn);
        }

        while(_time >= 90)
        {
            Instantiate(_enemys[Random.Range(0, _enemys.Length)], _directions[Random.Range(0, _directions.Length)],quaternion.identity);
            yield return new WaitForSeconds(_timerToSpawn);
        }
    }

    private void SpawnSpawner()
    {
        Instantiate(_enemySpawner, transform.position, quaternion.identity);
        _spawnedSpawner = true;
    }

    private void Instantiate(int enemy)
    {
        Instantiate(_enemys[enemy], _directions[Random.Range(0, _directions.Length)],quaternion.identity);
    }
}
