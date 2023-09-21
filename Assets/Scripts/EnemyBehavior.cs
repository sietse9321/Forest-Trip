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
    [SerializeField] GameObject sound1;
    [SerializeField] GameObject sound2;
    [SerializeField] GameObject sound3;
    [SerializeField] GameObject sound4;
    [SerializeField] GameObject sound5;
    [SerializeField] GameObject sound6;
    [SerializeField] GameObject sound7;
    [SerializeField] GameObject death;
    

    void Awake()
    {
        playerObject = GameObject.Find("henk 1 1");
        agent = gameObject.GetComponent<NavMeshAgent>();
        
        playerObject = GameObject.Find("henk 1 1");//find the game object of the player
        agent = gameObject.GetComponent<NavMeshAgent>();//gets the navmesh component
    }

    void FixedUpdate()
    {
        Sound();
        agent.SetDestination(playerObject.transform.position); //goes towards player trough navmesh
        if (health <= 0)
        {
            GameObject soundToDestroy = Instantiate(deathSound,transform.position, Quaternion.identity);//the sound the enemy makes when it dies
            Destroy(soundToDestroy, 3f);

            GameObject explosion = Instantiate(death, transform.position, Quaternion.identity);
            Destroy(explosion, 3f);
            Destroy(gameObject);//the enemy gets removed from the scene
        }
    }
    /// <summary>
    /// speelt een willekeurig geluid af van de enemies
    /// </summary>
    void Sound()
    {
        float randomNumber = Random.Range(0, 2000);
        switch (randomNumber)
        {
            case 1:
                GameObject soundToDestroy1 = Instantiate(sound1, transform.position, Quaternion.identity);
                Destroy(soundToDestroy1, 2f);
                break;
            case 2:
                GameObject soundToDestroy2 = Instantiate(sound2, transform.position, Quaternion.identity);
                Destroy(soundToDestroy2, 2f);
                break;
            case 3:
                GameObject soundToDestroy3 = Instantiate(sound3, transform.position, Quaternion.identity);
                Destroy(soundToDestroy3, 4f);
                break;
            case 4:
                GameObject soundToDestroy4 = Instantiate(sound4, transform.position, Quaternion.identity);
                Destroy(soundToDestroy4, 4f);
                break;
            case 5:
                GameObject soundToDestroy5 = Instantiate(sound5, transform.position, Quaternion.identity);
                Destroy(soundToDestroy5, 4f);
                break;
            case 6:
                GameObject soundToDestroy6 = Instantiate(sound6, transform.position, Quaternion.identity);
                Destroy(soundToDestroy6, 4f);
                break;
            case 7:
                GameObject soundToDestroy7 = Instantiate(sound7, transform.position, Quaternion.identity);
                Destroy(soundToDestroy7, 4f);
                break;
        }

    }
}
