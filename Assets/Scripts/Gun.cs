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
    public int magazine = 10;
    //float number
    float maxDistance = 100f;
    //transform
    [SerializeField] Transform shootPoint,muzzlePoint;
    //animator refrence
    Animator animator;
    TextMeshProUGUI ammoText;
    EnemyBehavior eB;
    [SerializeField] Material mat1, mat2;
    [SerializeField] GameObject background, muzzleFlash;
    void Start()
    {
        //gets the animator component from this gameobject
        animator = GetComponent<Animator>();
        ammoText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {

        if (magazine <= 3)
        {
            background.GetComponent<MeshRenderer>().material = mat2;
        }
        else
        {
            background.GetComponent<MeshRenderer>().material = mat1;
        }
        if (magazine == 0)
        {
            animator.SetBool("empty", true);
        }
        else
        {
            animator.SetBool("empty", false);
        }
        ammoText.text = magazine.ToString();
    }
    // Update is called once per frame
    void Update()
    {
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
                GameObject destory = Instantiate(muzzleFlash, muzzlePoint);
                Destroy(destory, 0.15f);
                //starts a coroutine so that the code can be used after this frame
                StartCoroutine(Time(0.15f, "rof"));
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("reload", true);
            //sets bool to true
            isReloading = true;
            StartCoroutine(Time(2f, "reload"));
            //ads magazine to totalammo
            if (magazine > 0)
            {
                magazine = 10;
            }
            if (magazine == 0)
            {
                magazine = 9;
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
                eB = hit.transform.gameObject.GetComponent<EnemyBehavior>();
                //get the script EnemyBehavior component
                eB.health--;
                //prints the raycast hit collider tag
                print(hit.collider.tag);
            }
        }
    }

    /// <summary>
    /// used to wait a certain amount of time
    /// </summary>
    /// <param name="_time"></param>
    /// <param name="_name"></param>
    /// <returns></returns>
    IEnumerator Time(float _time, string _name)
    {
        if (_name == "reload")
        {
            //waits for the amount of time
            yield return new WaitForSeconds(_time);
            animator.SetBool("reload", false);
            //sets isreloading to false
            isReloading = false;
        }
        else if (_name == "rof")
        {
            yield return new WaitForSeconds(_time);
            canFire = true;
        }
    }
}