using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //animator refrence
    Animator animator;
    //ints to store numbers
    [SerializeField] int magazine = 10, totalAmmo = 40;
    //bool true or false
    bool canFire = true, isReloading = false;
    // Start is called before the first frame update
    void Start()
    {
        //gets the animator component from this gameobject
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if mouse button 0 (left-click) is pressed down do code
        if (Input.GetMouseButtonDown(0))
        {
            //if magazine is bigger then 0 and canfire is true and isreloading is false do code
            if (magazine > 0 && canFire == true && isReloading == false)
            {
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
