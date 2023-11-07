using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private GameObject[] _object;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _parentForSpawned;
    private int _needed;
    private int _generated;
    private int _time;
    private void Start()
    {
        _needed = Random.Range(30, 40) * Random.Range(10, 20) * Random.Range(1, 3);
        _time = Random.Range(60, 90);
        _gameManager.time = _time;
        _gameManager.goal = _needed;
        _gameManager.TextsUpdate();
        Spawn();
    }
    private void Spawn()
    {
        while(_generated < _needed * 1.2f)
        {
            int randomObj = Random.Range(0, _object.Length);
            int randomY = Random.Range(0, 7);
            int randomX = Random.Range(-13, 13);
            var spawned = Instantiate(_object[randomObj], transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
            _generated += spawned.GetComponent<Dragged>().gold;
            spawned.transform.SetParent(_parentForSpawned.transform);
        }
        
        
        
    }
}
