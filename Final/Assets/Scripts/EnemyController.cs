using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Script for enemies to FOLLOW the player
    
    /*public Transform startMarker;
    public Transform endMarker;
    private bool facingRight = true;
    private Rigidbody2D robot2d;


    public float speed = 1.0F;


    private float startTime;


    private float journeyLength;


    void Start()
    {

        robot2d = GetComponent<Rigidbody2D>();

        startTime = Time.time;


        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }


    void FixedUpdate()
    {

        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        robot2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

        float distCovered = (Time.time - startTime) * speed;


        float fracJourney = distCovered / journeyLength;


        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Mathf.PingPong(fracJourney, 1));

        if (facingRight == false && hozMovement > 0)
        {
            Flip();
        }
        else if (facingRight == true && hozMovement < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    */


    public Rigidbody2D robot2d;
    public float speed = 2;
    public SpriteRenderer spriteRen;

    void Start()
    {
        robot2d = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();

    }


    void FixedUpdate()
    {
        robot2d.velocity = new Vector2(speed, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Robot Wall")
        {
            if (spriteRen.flipX == false)
            {
                spriteRen.flipX = true;
                speed = -2;
                return;

            }

            else if (spriteRen.flipX == true)
            {
                spriteRen.flipX = false;
                speed = 2;
                return;
            }

        }
    }


}
