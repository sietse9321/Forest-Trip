using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] int possibleSpawnPos = 36; //number of possible spawn location
    [SerializeField] int spawnRate = 500; //the interval of enemies to spawn
    [SerializeField] float spawnHeight = 5f; // spawn height of enemies
    [SerializeField] float spawnRadius = 25f; //radius of the spawn circle
    [SerializeField] int count = 0; //counter for spawning enemies

    private void FixedUpdate()
    {
        if (count % spawnRate == 0)//if count is modulo spawn rate then spawn a enemy
        {
            SpawnObjectsInCircle();
        }
        count++;//telt op met 50 per seconden
    }
    /// <summary>
    /// this method calculates the spawn location of the enemy
    /// </summary>
    void SpawnObjectsInCircle()
    {
        float angle = Random.Range(1, 37) * Mathf.PI * 2 / possibleSpawnPos;//picks one of the 36 random directions to spawn a enemy in
        Vector3 spawnPosition = transform.position + new Vector3(Mathf.Cos(angle) * spawnRadius, spawnHeight, Mathf.Sin(angle) * spawnRadius);//calculates a place to spawn a enemy in
        GameObject newObject = Instantiate(enemy, spawnPosition, Quaternion.identity);//spawns a new enemy
    }
}
