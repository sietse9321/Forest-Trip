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
            JumpStop();
        }
        if (Input.GetKeyUp("space"))
        {
            JumpStart();
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
            shoot.Play();
        }
        if (Input.GetKey(KeyCode.R))
        {
            reload.Play();
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
    

}











