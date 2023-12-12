using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _delay;
    [SerializeField] private float radius = 3f;
    [SerializeField] private bool isGameGoing = true;

    void Start()
    {
        
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        while (isGameGoing)
        {
            SpawnRandomly2D();
            yield return new WaitForSeconds(_delay);
        }   
    }

    private void SpawnRandomly2D()
    {
        Vector3 randomPos = Random.insideUnitSphere * radius;
        randomPos += transform.position;
        randomPos.y = 0f;

        Vector3 direction = randomPos - transform.position;
        direction.Normalize();

        float dotProduct = Vector3.Dot(transform.forward, direction);
        float dotProductAngle = Mathf.Acos(dotProduct / transform.forward.magnitude * direction.magnitude);

        randomPos.x = Mathf.Cos(dotProductAngle) * radius + transform.position.x;
        randomPos.y = Mathf.Sin(dotProductAngle * (Random.value > 0.5f ? 1f : -1f)) * radius + transform.position.y;
        randomPos.z = transform.position.z;

        GameObject go = Instantiate(_prefabs[0], randomPos, Quaternion.identity);
        go.transform.position = randomPos;
    }
}
