using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] int possibleSpawnPos = 36; //aantal mogelijke lokaties om te instantiaten
    [SerializeField] int spawnrate = 500; //de interval voor het spawnen van van enemies
    [SerializeField] float spawnHeight = 5f; // de spawn hoogte van de enemies
    [SerializeField] float spawnRadius = 25f; //radius spawn cirkel
    [SerializeField] int count = 0; //teller voor het spawnen van baddies

    private void FixedUpdate()
    {
        if (count % spawnrate == 0)//als count modulo spawnrate is dan word er een enemy gespawned
        {
            SpawnObjectsInCircle();
        }
        count++;
    }
    /// <summary>
    /// deze method berekent een cirkel rondom de speler en zet ergens op die radius een enemy
    /// </summary>
    void SpawnObjectsInCircle()
    {
        float angle = Random.Range(1, 37) * Mathf.PI * 2 / possibleSpawnPos;//bepaald een willekeurige van de 36 verschillende richtingen
        Vector3 spawnPosition = transform.position + new Vector3(Mathf.Cos(angle) * spawnRadius, spawnHeight, Mathf.Sin(angle) * spawnRadius);//berekent de plaats om een enemy te spawnen
        GameObject newObject = Instantiate(enemy, spawnPosition, Quaternion.identity);//spawnt een nieuwe enemy
    }
}
