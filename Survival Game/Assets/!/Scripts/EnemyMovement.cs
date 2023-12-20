using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private Vector2 _direction;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _targetTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        _direction = (_targetTransform.position - transform.position).normalized;
    }


    void FixedUpdate()
    {
        _rb.velocity = _direction * _speed * Time.fixedDeltaTime;
    }
}
