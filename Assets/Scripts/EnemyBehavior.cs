using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float health = 5f;
    // Update is called once per frame
    void Update()
    {
        //berekent de richting waar de enemy naartoe beweegt 
        Vector3 moveDirection = (playerObject.transform.position - transform.position).normalized;
        //gebruikt vervolgens het resultaat van hier boven om richting de speler te bewegen
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
