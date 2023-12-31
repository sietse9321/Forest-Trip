using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public float hitInterval = 2;
    public int pointsPerHit = 25;
    private float lastHitWhen;
    public EnemySpawner spawner;

    private void Start()
    {
        health = maxHealth;
        lastHitWhen = Time.fixedTime;
    }
    void OnCollisionEnter(Collision collision) //if the player makes a collision run this code
    { //if the player makes a collision with the enemies AND enough time has passed since the last time the player took damage
        if (collision.gameObject.CompareTag("Enemy") && lastHitWhen < Time.fixedTime) 
        {
            print("player lost health");
            health -= pointsPerHit;//player loses a certain amount of health
            lastHitWhen += hitInterval;//a new last time the player was hit is set
            if (health <= 0)//if the player has zero or less health points he dies
            {
                print("player has no health");
                SceneManager.LoadScene(2);
            }
        }
    }
}
