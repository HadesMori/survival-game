using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour
{
    public GameObject ClosestEnemy { get; private set; }
    public KdTree<EnemyMovement> enemies = new KdTree<EnemyMovement>();
    
    void Update()
    {
        EnemyMovement enemy = FindObjectOfType<EnemyMovement>();

        if (!enemies.Contains(enemy)){
            enemies.Add(enemy);
        }
        ClosestEnemy = enemies.FindClosest(transform.position).gameObject;
    }

}
