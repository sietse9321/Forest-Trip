using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Animator animator;
    [SerializeField] int magazine = 10, totalAmmo = 40, maxAmmo = 10;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (magazine > 0)
            {
                animator.Play("gun_shoot");
                magazine--;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
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
                totalAmmo= 0;
            }
        }
    }
}
