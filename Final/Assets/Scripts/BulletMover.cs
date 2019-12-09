using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;

    void Start()
    {
        
        rb.velocity = transform.right * speed;
                
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            
            Destroy(gameObject);

        }
    }
}
