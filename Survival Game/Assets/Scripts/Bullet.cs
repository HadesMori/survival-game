using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _aliveForSeconds;
    private Rigidbody2D _rb;
    private FindClosest _findClosest;
    private Vector2 _direction;
    private Vector3 _enemyPos;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _findClosest = GameObject.Find("Player").GetComponent<FindClosest>();
        if(_findClosest.ClosestEnemy != null)
        {
            _enemyPos = _findClosest.ClosestEnemy.transform.position;
            _direction = (_enemyPos - _rb.transform.position).normalized;
            StartCoroutine(LiveFor(_aliveForSeconds));
        }
    }

    void FixedUpdate()
    {
        _rb.velocity = _direction * _speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.TryGetComponent(out Health enemyHealth);
            enemyHealth.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    IEnumerator LiveFor(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
