using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    public float health = 3f;
    NavMeshAgent agent;
    [SerializeField] GameObject hurtSound;
    [SerializeField] GameObject deathSound;
    
    // Update is called once per frame
    void Awake()
    {
        playerObject = GameObject.Find("henk 1 1");
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        agent.SetDestination(playerObject.transform.position);
        if (health <= 0)
        {
            GameObject soundToDestroy = Instantiate(deathSound, transform.position,Quaternion.identity);
            Destroy(soundToDestroy,2f);
            Destroy(gameObject);
        }
    }
}
