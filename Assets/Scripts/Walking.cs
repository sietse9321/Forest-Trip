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
    void Start()
    {
        walk.SetActive(false); //bools are set to false so when the gameplay segment starts the player stands still
        jump.SetActive(false);
        crawl.SetActive(false);
    }
    void Update()
    {
        //check if one of the WASD keys is pressed down to start walking
        if (Input.GetKeyDown("w") || Input.GetKeyDown("s") || Input.GetKeyDown("d") || Input.GetKeyDown("a"))
        {
            WalkStart();
        }
        //checks if one of the WASD keys is let go to stop walking
        if (Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("s") || Input.GetKeyUp("d"))
        {
            WalkStop();
        }
        //checks if the space key is pressed down to start jumping
        if (Input.GetKeyDown("space"))
        {
            JumpStart();
        }
        //checks if the space key is let go to stop jumping 
        if (Input.GetKeyUp("space"))
        {
            JumpStop();
        }
        //checks if the left shift key is pressed down to start running
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            RunStart();
        }
        //checks if the left shift key is let go to stop running
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunStop();
        }
        //checks if the left control key is pressed down to start crouching
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            CrawlStart();
        }
        //checks if the left control key is let go to stop crouching
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            CrawlStop();
        }
        //checks if the left mouse button is pressed down to fire the pistol
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //checks if the gun is empty when the gun is fired
            if (gn.magazine > 0)
            {
                shoot.Play();//plays fire sound
            }
            else
            {
                jammed.Play();//plays empty click sound
            }
        }
        //checks if the r key is pressed down to reload
        if (Input.GetKey(KeyCode.R))
        {
            reload.Play();
        }
    }
    //methods to to set variables
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