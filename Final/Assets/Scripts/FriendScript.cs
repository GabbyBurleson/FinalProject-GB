using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendScript : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public Transform startMarker;
    public Transform endMarker;
    public float speed;


    public AudioSource musicSource;
    

    private float nextFire;

    private bool facingRight = true;

    private float startTime;

    private float journeyLength;

    void Start()
    {
        startTime = Time.time;


        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

   //Responsible for Bullet Fire time 
    void Update()
    {
        if (Input.GetButton("Jump") && Time.time > nextFire)
        
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            musicSource.Play();


        }

        float distCovered = (Time.time - startTime) * speed;


        float fracJourney = distCovered / journeyLength;


        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Mathf.PingPong(fracJourney, 1));

        
    }


    //COME BACK TO BELOW
    
    //Responsible for X axis flip
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");

        if (facingRight == false && hozMovement > 0)
        {
            Flip();
        }
        else if (facingRight == true && hozMovement < 0)
        {
            Flip();
        }

       
    }


    //PRIVATE responsible for image flip
    void Flip()
    {
        facingRight = !facingRight;
        

        transform.Rotate(0f, 180f, 0f);

    }
}
