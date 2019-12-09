using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;



    private int scoreValue = 0;
    private int livesValue = 3;

    void Start()
    {
        musicSource.Play();
        musicSource.loop = true;

    }

    
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void SetScore()
    {
        

        if (scoreValue >= 10)
        {
            
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            musicSource.loop = false;
            

        }

    }


    void SetLives()
    {
        

        if (livesValue == 0)
        {
            
            musicSource.clip = musicClipThree;
            musicSource.Play();
            musicSource.loop = false;
            
        }


    }
}
