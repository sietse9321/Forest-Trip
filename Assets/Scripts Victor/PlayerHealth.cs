using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public float hitInterval = 2;
    public int pointsPerHit = 25;
    private float lastHitWhen;

    private void Start()
    {
        health = maxHealth;
        lastHitWhen = Time.fixedTime;
    }
    private void OnTriggerEnter2D(Collider2D collision) //if the player makes a collision run this code
    { //if the player makes a collision with the enemies AND enough time has passed since the last time the player took damage
        if (collision.CompareTag("enemy") && lastHitWhen + hitInterval > Time.fixedTime) 
        {
            health -= pointsPerHit;
            lastHitWhen += hitInterval;
            if (health <= 0)
            {
                //trigger end of game here
            }
        }
    }
}
