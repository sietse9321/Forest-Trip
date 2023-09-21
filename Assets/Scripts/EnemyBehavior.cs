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
    [SerializeField] GameObject death;

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
            GameObject soundToDestroy = Instantiate(deathSound);
            Destroy(soundToDestroy, 2f);
            GameObject explosion = Instantiate(death, transform.position, Quaternion.identity);
            Destroy(explosion, 3f);
            Destroy(gameObject);
        }
    }
    void Sound()
    {
        float randomNumber = Random.Range(0, 1750);
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
        }

    }
}
