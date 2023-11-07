using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Claw : MonoBehaviour
{
    private bool _isDroped;
    private bool _isCollect;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private int _direction = 1;
    private Vector3 _startPosition;
    private GameManager _gameManager;
    private GameObject _dragged;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _gameManager = FindObjectOfType<GameManager>(); 
        _startPosition = transform.position;
    }
    private void Update()
    {
        if(_isDroped == false)
        {
            if (_transform.localEulerAngles.z > 60 && _transform.localEulerAngles.z < 300)
                _direction *= -1;
            _transform.Rotate(new Vector3(0,0, 40 * -_direction * Time.deltaTime));
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            _isDroped = true;
        }
        if(_isDroped == true && _isCollect == false)
        {
            _transform.position = Vector2.MoveTowards(_transform.position, _transform.GetChild(0).position, 20 * Time.deltaTime);
        }
        if(_isCollect == true)
        {
            _transform.position = Vector2.MoveTowards(_transform.position, _startPosition, _dragged.GetComponent<Dragged>().collectSpeed * Time.deltaTime);
            if(_dragged != null)
                _dragged.transform.position = _transform.GetChild(0).position;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "CollectZone" && _isCollect == true)
        {
            _isCollect = false;
            _isDroped = false;
            _transform.position = _startPosition;
            _transform.rotation = new Quaternion(0, 0, 0, 0);

            Destroy(_dragged);
            _gameManager.score += _dragged.GetComponent<Dragged>().gold;
            _gameManager.TextsUpdate();
        }
        if (collision.transform.tag == "Collect" && this.transform.tag != "Collect")
        {
            _isCollect = true;
            _dragged = collision.gameObject;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall")
        {
            _transform.position = _startPosition;
            _isDroped = false;
            _isCollect = false;
        }        
    }
}
