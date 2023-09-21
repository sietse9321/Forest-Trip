using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    //invisible game object that play the audio segments
    public GameObject walk;
    public GameObject jump;
    public GameObject crawl;
    //audio segments
    public AudioSource shoot;
    public AudioSource reload;
    public AudioSource damage;
    public AudioSource jammed;
    //references to other scripts
    public Gun gn;
    public EnemyBehavior enemy;
    void Start()
    {
        walk.SetActive(false);
        jump.SetActive(false);
        crawl.SetActive(false);
    }
    void Update()
    {
        //checks if the WASD buttons are being pressed
        if (Input.GetKeyDown("w") || Input.GetKeyDown("s") || Input.GetKeyDown("d") || Input.GetKeyDown("a"))
        {
            WalkStart();//starts the walking noise 
        }
        //checks if the WASD buttons are being released
        if (Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("s") || Input.GetKeyUp("d"))
        {
            WalkStop();//stops the walking noise
        }
        //checks if the space button is being pushed
        if (Input.GetKeyDown("space"))
        {
            JumpStart();//plays jumping noise
        }
        //checks if the space button is released
        if (Input.GetKeyUp("space"))
        {
            JumpStop();//stops with jumping noise 
        }
        //checks if left control is being pressed
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            CrawlStart();//starts crawling noise
        }
        //checks if left control is being released
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            CrawlStop();//stops crawling noise
        }
        //checks if the left mouse button is being pressed
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //check if the magazine level if greater than zero
            if (gn.magazine > 0)
            {
                shoot.Play();//plays gunfire sound
            }
            else
            {
                jammed.Play();//plays clicking sound
            }
        }
        //checks if the r button is pressed
        if (Input.GetKey(KeyCode.R))
        {
            reload.Play();//plays reload sound
        }
    }
    //these methods activate and deactivate sounds
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











