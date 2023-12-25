using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private int _maxPrefabs;
    [SerializeField] private float _delay;
    [SerializeField] private float _radius = 3f;
    [SerializeField] private bool isEndlessly;
    private bool _isGameGoing = true;
    public int InstancesNum;

    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        while (_isGameGoing)
        {
            if(isEndlessly || InstancesNum < _maxPrefabs)
            {
                SpawnRandomly2D();
            }
            yield return new WaitForSeconds(_delay);
        }   
    }

    private void SpawnRandomly2D()
    {
        int randomPrefab = Random.Range(0, _prefabs.Length);
        Vector3 randomPos = Random.insideUnitSphere * _radius;
        randomPos += transform.position;
        randomPos.y = 0f;

        Vector3 direction = randomPos - transform.position;
        direction.Normalize();

        float dotProduct = Vector3.Dot(transform.forward, direction);
        float dotProductAngle = Mathf.Acos(dotProduct / transform.forward.magnitude * direction.magnitude);

        randomPos.x = Mathf.Cos(dotProductAngle) * _radius + transform.position.x;
        randomPos.y = Mathf.Sin(dotProductAngle * (Random.value > 0.5f ? 1f : -1f)) * _radius + transform.position.y;
        randomPos.z = transform.position.z;

        GameObject go = Instantiate(_prefabs[randomPrefab], randomPos, Quaternion.identity);
        go.transform.position = randomPos;
        InstancesNum++;
    }
}
