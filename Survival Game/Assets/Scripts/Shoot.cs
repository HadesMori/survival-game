using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float attackSpeed;
    private FindClosest _findClosest;

    void Start()
    {
        _findClosest = GetComponent<FindClosest>();
        StartCoroutine("Fire");
    }

    void Update()
    {
        
    }

    IEnumerator Fire()
    {
        while (true)
        {
            if(_findClosest.ClosestEnemy != null)
            {
                Instantiate(_projectile, transform.position, transform.rotation);
            }
            yield return new WaitForSeconds(1 / attackSpeed);
        }
    }
}
