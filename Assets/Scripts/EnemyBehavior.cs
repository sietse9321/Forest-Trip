using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    public float health = 3f;
    NavMeshAgent agent;
    [SerializeField] GameObject hurtSound;
    [SerializeField] GameObject deathSound;
    [SerializeField] GameObject deathParticles;
    [SerializeField] List<GameObject> soundObjects;

    // Update is called once per frame
    void Awake()
    {
        playerObject = GameObject.Find("henk 1 1");
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        Sound();
        agent.SetDestination(playerObject.transform.position);
        if (health <= 0)
        {
            GameObject soundToDestroy = Instantiate(deathSound,transform.position, Quaternion.identity);
            Destroy(soundToDestroy, 3f);
            GameObject explosion = Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(explosion, 3f);
            Destroy(gameObject);
        }
    }
    void Sound()
    {
        int randomNumber = Random.Range(0, 2000);
        switch (randomNumber)
        {
            case 1:
                GameObject soundToDestroy1 = Instantiate(soundObjects[0], transform.position, Quaternion.identity);
                Destroy(soundToDestroy1, 2f);
                break;
            case 2:
                GameObject soundToDestroy2 = Instantiate(soundObjects[1], transform.position, Quaternion.identity);
                Destroy(soundToDestroy2, 2f);
                break;
            case 3:
                GameObject soundToDestroy3 = Instantiate(soundObjects[2], transform.position, Quaternion.identity);
                Destroy(soundToDestroy3, 4f);
                break;
            case 4:
                GameObject soundToDestroy4 = Instantiate(soundObjects[3], transform.position, Quaternion.identity);
                Destroy(soundToDestroy4, 4f);
                break;
            case 5:
                GameObject soundToDestroy5 = Instantiate(soundObjects[4], transform.position, Quaternion.identity);
                Destroy(soundToDestroy5, 4f);
                break;
            case 6:
                GameObject soundToDestroy6 = Instantiate(soundObjects[5], transform.position, Quaternion.identity);
                Destroy(soundToDestroy6, 4f);
                break;
            case 7:
                GameObject soundToDestroy7 = Instantiate(soundObjects[6], transform.position, Quaternion.identity);
                Destroy(soundToDestroy7, 4f);
                break;
        }
    }
}