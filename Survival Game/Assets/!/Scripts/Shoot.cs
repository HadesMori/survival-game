using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    private FindClosest _findClosest;
    private PlayerStats _playerStats;

    void Start()
    {
        _findClosest = GetComponent<FindClosest>();
        _playerStats = GetComponent<PlayerStats>();
        StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        while (true)
        {
            if(_findClosest.ClosestEnemy != null)
            {
                Instantiate(_projectile, transform.position, transform.rotation);
            }
            yield return new WaitForSeconds(1 / _playerStats.AttackSpeed);
        }
    }
}
