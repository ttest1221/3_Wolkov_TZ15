using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragged : MonoBehaviour
{   
     
    [SerializeField] private bool _isBag;

    private GameManager _gameManager;
    private Transform _transform;

    public int collectSpeed;
    public int gold;
    private void Start()
    {
        _transform = GetComponent<Transform>();
        _gameManager = FindObjectOfType<GameManager>();
        if (_isBag == true)
            gold = Random.Range(40, 150);
    }

}
