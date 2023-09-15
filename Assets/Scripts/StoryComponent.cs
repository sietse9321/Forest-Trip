using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryComponent : MonoBehaviour
{
    public AudioSource intro;
    public AudioSource outro;
    // Start is called before the first frame update
    void Start()
    {
        intro.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
