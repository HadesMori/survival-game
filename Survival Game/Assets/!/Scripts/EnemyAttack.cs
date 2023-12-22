using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackSpeed;
    private bool _canDealDamage;

    private void Start()
    {
        _canDealDamage = true;    
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth);
            if (_canDealDamage)
            {
                StartCoroutine(DealDamage(playerHealth));
            }
        }
    }

    IEnumerator DealDamage(PlayerHealth health)
    {
        _canDealDamage = false;
        health.TakeDamage(_damage);
        yield return new WaitForSeconds(1 / _attackSpeed);
        _canDealDamage = true;
    }
}
