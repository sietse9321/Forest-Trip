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
    public AudioSource spawn;
    public AudioSource damage;
    
    
    // Update is called once per frame
    private void Awake()
    {
        playerObject = GameObject.Find("henk 1 1");
        agent = gameObject.GetComponent<NavMeshAgent>();
        spawn.Play();
    }

    void FixedUpdate()
    {
        if(health == 2f)
        {
            damage.Play();
        }
        else if(health == 1f)
        {
            damage.Play();
        }
        agent.SetDestination(playerObject.transform.position);
        if (health <= 0)
        {
            Destroy(gameObject);
           
        }
        
    }
}
