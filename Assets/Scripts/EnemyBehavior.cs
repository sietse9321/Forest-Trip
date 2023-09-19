using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject playerObject; //gameobject player linkes so the enemy can find it
    public float health = 3f; //health so the enemy can die
    NavMeshAgent agent; //she nav on my mesh till i agent
    [SerializeField] GameObject hurtSound; //seperate game object for sound effects for when the enemy dies the sound does not immediately stop with it
    [SerializeField] GameObject deathSound; //read comment above
    void Awake()
    {
        playerObject = GameObject.Find("henk 1 1"); //find the location of the player
        agent = gameObject.GetComponent<NavMeshAgent>(); //grabs the navmesh agent
    }

    void FixedUpdate()
    {
        agent.SetDestination(playerObject.transform.position);//navigates to the player
        if (health <= 0)//if the enemy hos no healt
        {
            GameObject soundToDestroy = Instantiate(deathSound);//dying noise
            Destroy(soundToDestroy,2f);
            Destroy(gameObject);//the enemy dies, is ridden from this world
        }
    }
}
