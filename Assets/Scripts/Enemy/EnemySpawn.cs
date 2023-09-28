using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] _enemys;
    [SerializeField] Vector2[] _directions;
    [SerializeField] float _timerToSpawn = 1f;
    [SerializeField] private GameObject _enemySpawner;
    [SerializeField] private float _time;
    [SerializeField] private float _waitBeforeStart = 2f;
    [SerializeField] private Transform _parent;
    public static int _hazard = 1;
    private bool _spawnedSpawner = false;
    private bool _startedToSpawn = false;

    void Update()
    {
        _time += Time.deltaTime;
        
        if(_time >= _waitBeforeStart && _startedToSpawn == false)
        {
            StartCoroutine(Spawner());
            _startedToSpawn = true;
        }

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
            GameObject setEnemy = Instantiate(_enemys[Random.Range(0, _enemys.Length)], _directions[Random.Range(0, _directions.Length)],quaternion.identity);
            setEnemy.transform.SetParent(_parent);
            setEnemy.GetComponent<Enemy>()._maxHP += _hazard;
            setEnemy.GetComponent<Enemy>()._damage += _hazard;
            yield return new WaitForSeconds(_timerToSpawn);
        }
    }

    private void SpawnSpawner()
    {
        _time = 0;
        _hazard++;
        _spawnedSpawner = true;
        Instantiate(_enemySpawner, transform.position, quaternion.identity);
    }

    private void Instantiate(int enemy)
    {
        GameObject setEnemy = Instantiate(_enemys[enemy], _directions[Random.Range(0, _directions.Length)],quaternion.identity);
        setEnemy.transform.SetParent(_parent);
    }
}
