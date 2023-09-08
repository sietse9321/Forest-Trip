using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] public float health = 5f;
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        //berekent de richting waar de enemy naartoe beweegt 
        Vector3 moveDirection = (playerObject.transform.position - transform.position).normalized;
        //gebruikt vervolgens het resultaat van hier boven om richting de speler te bewegen
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
