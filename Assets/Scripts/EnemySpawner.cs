using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] int possibleSpawnPos = 36; //aantal mogelijke lokaties om te instantiaten
    [SerializeField] float radius = 25f; //radius spawn cirkel
    [SerializeField] int count = -1000; //teller voor het spawnen van baddies

    private void FixedUpdate()
    {
        if (count % 500 == 0)
        {
            SpawnObjectsInCircle();
        }
        count++;
    }
    void SpawnObjectsInCircle()
    {
        float angle = Random.Range(1, 37) * Mathf.PI * 2 / possibleSpawnPos;
        Vector3 spawnPosition = transform.position + new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
        GameObject newObject = Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}
