using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    private void OnDestroy()
    {
        if(GameObject.Find("Player") != null)
        {
            GameObject.Find("Player").TryGetComponent(out FindClosest findClosest);
            List<EnemyMovement> enemyList = findClosest.enemies.ToList();
            enemyList.Remove(GetComponent<EnemyMovement>());
            findClosest.enemies = new KdTree<EnemyMovement>(enemyList);
        }
        if(GameObject.Find("SpawnManager") != null)
        {
            GameObject.Find("SpawnManager").TryGetComponent(out SpawnManager spawnManager);
            spawnManager.InstancesNum--;
        }
    }
}
