using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damage;
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
            collision.gameObject.TryGetComponent<Health>(out Health playerHealth);
            if (_canDealDamage)
            {
                StartCoroutine(DealDamage(playerHealth));
            }
        }
    }

    IEnumerator DealDamage(Health health)
    {
        _canDealDamage = false;
        health.TakeDamage(_damage);
        yield return new WaitForSeconds(1 / _attackSpeed);
        _canDealDamage = true;
    }
}
