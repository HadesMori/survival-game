using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private int _lifeTime;

    void Start()
    {
        StartCoroutine(LiveFor(_lifeTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.TryGetComponent(out Level playerLevel);
            playerLevel.Increase(_value);
            Destroy(gameObject);
        }
    }
    IEnumerator LiveFor(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
