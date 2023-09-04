using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //bool true or false
    bool canFire = true, isReloading = false;
    //ints to store numbers
    [SerializeField] int magazine = 10, totalAmmo = 40;
    //float number
    float maxDistance = 100f;
    //transform
    [SerializeField] Transform shootPoint;
    //animator refrence
    Animator animator;
    TextMeshProUGUI ammoText;
    void Start()
    {
        //gets the animator component from this gameobject
        animator = GetComponent<Animator>();
        ammoText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = magazine.ToString();
            Debug.DrawRay(shootPoint.transform.position, shootPoint.transform.forward * maxDistance);
        //if mouse button 0 (left-click) is pressed down do code
        if (Input.GetMouseButtonDown(0))
        {
            //if magazine is bigger then 0 and canfire is true and isreloading is false do code
            if (magazine > 0 && canFire == true && isReloading == false)
            {
                print("Shooting");
                Shoot();
                //sets canfire to false
                canFire = false;
                //plays the gun_shoot animation
                animator.Play("gun_shoot");
                //lowers magazine by 1
                magazine--;
                //starts a coroutine so that the code can be used after this frame
                StartCoroutine(Time(0.25f, "rof"));
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //sets bool to true
            isReloading = true;
            StartCoroutine(Time(2f, "reload"));
            //ads magazine to totalammo
            totalAmmo += magazine;
            if (totalAmmo > 10)
            {
                if (magazine > 0)
                {
                    magazine = 10;
                    totalAmmo -= 10;
                }
                if (magazine == 0)
                {
                    magazine = 9;
                    totalAmmo -= 9;
                }
            }
            else
            {
                magazine = totalAmmo;
                totalAmmo = 0;
            }
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        //if ray origin position, direction, out hit, float maxDistance = true do code
        if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.forward, out hit, maxDistance))
        {
            //if raycasthit hit collider tag is equal to "Enemy"
            if (hit.collider.tag == "Enemy")
            {
                //get the script EnemyBehavior component

                //prints the raycast hit collider tag
                print(hit.collider.tag);
            }
        }
    }

    /// <summary>
    /// used to wait a certain amount of time
    /// </summary>
    /// <param name="time"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    IEnumerator Time(float time, string type)
    {
        if (type == "reload")
        {
            //waits for the amount of time
            yield return new WaitForSeconds(time);
            //sets isreloading to false
            isReloading = false;
        }
        else if (type == "rof")
        {
            yield return new WaitForSeconds(time);
            canFire = true;
        }
    }
}