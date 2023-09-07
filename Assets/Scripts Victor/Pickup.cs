using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PlayerHealth pH;

    public bool isHealth;
    public bool isAmmo;
    public bool pickedUp = false;

    public int healValue = 50;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (isHealth)
            {
                if (pH.health < pH.maxHealth)
                    if (pH.health + healValue > pH.maxHealth)
                    {
                        pH.health = pH.maxHealth;
                        pickedUp = true;
                    }
                    else
                    {
                        pH.health = pH.health + healValue;
                        pickedUp = true;
                    }
            }
            else if (isAmmo)
            {

            }
        }
    }

    private void Update()
    {
        if (pickedUp)
        {
            Destroy(this.gameObject);
        }
    }
}
