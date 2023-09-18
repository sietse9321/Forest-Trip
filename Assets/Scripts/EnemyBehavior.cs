using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject playerObject; //gameobject speler gelinkt zodat de enemy neer hem toe gaat
    public float health = 3f; //health zodat de enemy kan sterven 
    NavMeshAgent agent; //she nav on my mesh till i agent
    [SerializeField] GameObject hurtSound; //losse game object voor geluid zodat het niet stopt wanneer de enemyGameObject spontaan stopt met bestaan
    [SerializeField] GameObject deathSound; //lees de comment hierboven
    void Awake()
    {
        playerObject = GameObject.Find("henk 1 1"); //vind de locatie van de speler
        agent = gameObject.GetComponent<NavMeshAgent>(); //pakt de nav mesh agent
    }

    void FixedUpdate()
    {
        agent.SetDestination(playerObject.transform.position);//navigeer naar de speler
        if (health <= 0)//als de enemy geen health meer heeft
        {
            GameObject soundToDestroy = Instantiate(deathSound);//sterf geluid
            Destroy(soundToDestroy,2f);
            Destroy(gameObject);//sterft daadwerkelijk
        }
    }
}
