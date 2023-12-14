using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float _maxHP;
    [SerializeField] protected float _currentHP;

    void Update()
    {
        Die();
    }

    public void TakeDamage(float damage)
    {
        _currentHP -= damage;
    }

    private void Die()
    {
        if(_currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
