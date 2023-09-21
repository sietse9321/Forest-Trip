using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public GameObject walk;
    public GameObject jump;
    public GameObject crawl;
    public AudioSource shoot;
    public AudioSource reload;
    public Gun gn;
    public AudioSource jammed;
    public GameObject running;
    public EnemyBehavior enemy;
    public AudioSource damage;
    

    // Start is called before the first frame update
    void Start()
    {
        

        walk.SetActive(false);
        jump.SetActive(false);
        crawl.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            WalkStart();
        }
        if (Input.GetKeyDown("s"))
        {
            WalkStart();
        }
        if (Input.GetKeyDown("d"))
        {
            WalkStart();
        }
        if (Input.GetKeyDown("a"))
        {
            WalkStart();
        }
        if (Input.GetKeyUp("w"))
        {
            WalkStop();
        }
        if (Input.GetKeyUp("a"))
        {
            WalkStop();
        }
        if (Input.GetKeyUp("s"))
        {
            WalkStop();
        }
        if (Input.GetKeyUp("d"))
        {
            WalkStop();
        }
        if (Input.GetKeyDown("space"))
        {
            JumpStart();
        }
        if (Input.GetKeyUp("space"))
        {
            JumpStop();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            RunStart();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunStop();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            CrawlStart();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            CrawlStop();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
           if(gn.magazine > 0)
            {
                shoot.Play();
            }
            else
            {
                jammed.Play();
            }
        }
        if (Input.GetKey(KeyCode.R))
        {
            reload.Play();
        }
        if(enemy.health == 2 || enemy.health == 1)
        {
            damage.Play();
        }
        
        


    }







    void WalkStart()
    {
        walk.SetActive(true);
    }
    void WalkStop()
    {
        walk.SetActive(false);
    }
    void JumpStart()
    {
        jump.SetActive(true);
    }
    void JumpStop()
    {
        jump.SetActive(false);
    }
    void CrawlStart()
    {
        crawl.SetActive(true);
    }
    void CrawlStop()
    {
        crawl.SetActive(false);
    }
    void RunStart()
    {
        running.SetActive(true);
    }
    void RunStop()
    {
        running.SetActive(false);
    }


}











