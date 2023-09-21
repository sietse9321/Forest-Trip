using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    //public variable for ease of access in other scripts to link and interact with because of the nature of pickups
    public PlayerHealth pH;

    public bool isHealth;
    public bool isAmmo;
    public bool pickedUp = false;

    public int healValue = 50;
    
    private void OnTriggerEnter(Collider collider)//method that triggers when a collider gets entered
    {
        if (collider.gameObject.tag == "Player") //if the collider inside this one has the tag player execute code block
        {
            if (isHealth) //check for the type of pickup
            {
                if (pH.health < pH.maxHealth) //check for the current health of the player
                    if (pH.health + healValue > pH.maxHealth) //check to make sure player doesn't overheal
                    {
                        pH.health = pH.maxHealth; //failsafe to set player to maxhealth
                        pickedUp = true;
                    }
                    else
                    {
                        pH.health = pH.health + healValue; //if healing amount would not exceed maxhealth give full healing amount
                        pickedUp = true;
                    }
            }
            else if (isAmmo)
            {

            }
        }
    }

    private void Update() //honestly a lazy check for whether or not the player picked up the pickup could have been a called method instead
    {
        if (pickedUp)
        {
            Destroy(this.gameObject); //destroys pickup on enter
        }
    }
}
