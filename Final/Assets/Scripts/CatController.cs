using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatController : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;
    Animator anim;
    private bool facingRight = true;

    public AudioSource musicSource;
    //public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;
    public AudioClip musicClipFour;
    public AudioClip musicClipFive;

   

    public Text score;
    public Text lives;
    private int scoreValue = 0;
    private int livesValue = 3;
    public Text winText;
    public Text loseText;


    // Start is called before the first frame update
    void Start()
    {
        
        rd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SetScore();
        SetLives();
        winText.text = "";
        loseText.text = "";
        //musicSource.clip = musicClipOne;
        //musicSource.Play();
        //musicSource.loop = true;

    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit(); 
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 0);
        } 

        
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


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            scoreValue += 1;
            SetScore();

            musicSource.clip = musicClipFive;
            musicSource.Play();
            musicSource.loop = false;
        }


        if (other.gameObject.CompareTag("Life"))
        {
            other.gameObject.SetActive(false);

            livesValue += 1;
            SetLives();

            musicSource.clip = musicClipFive;
            musicSource.Play();
            musicSource.loop = false;
        }


        if (other.gameObject.CompareTag("Shield"))
        {
            /*other.gameObject.SetActive(false);

            scoreValue += 1;
            SetScore();*/

          

            musicSource.clip = musicClipFive;
            musicSource.Play();
            musicSource.loop = false;
        }


        if (other.gameObject.CompareTag("Doorway"))
        {
            transform.position = new Vector2(-15.0f, -45.0f);

        }


    }

    

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Doorway"))
        {
            transform.position = new Vector2(-15.0f, -45.0f);


        }
    }*/

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);

            }

        }

       
        if (collision.gameObject.CompareTag("Enemy"))
        {
            livesValue -= 1;
            SetLives();
            musicSource.clip = musicClipFour;
            musicSource.Play();
            musicSource.loop = false;
        }

        if (collision.gameObject.CompareTag("Enemy Objects"))
        {
            livesValue -= 1;
            SetLives();
            musicSource.clip = musicClipFour;
            musicSource.Play();
            musicSource.loop = false;
        }
    }

    
    void SetScore()
    {
        score.text = "Score: " + scoreValue.ToString();

        if (scoreValue >= 10)
        {
            winText.text = "You win! Game created by Gabby Burleson!";
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            musicSource.loop = false;
            gameObject.GetComponent<Renderer>().enabled = false;
            rd2d.bodyType = RigidbodyType2D.Static;
            anim.SetInteger("State", 0);
            
        }

    }


   void SetLives()
    {
        lives.text = "Lives: " + livesValue.ToString();

        if (livesValue == 0)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            rd2d.bodyType = RigidbodyType2D.Static;
            musicSource.clip = musicClipThree;
            musicSource.Play();
            musicSource.loop = false;
            loseText.text = "You Lose!";
            anim.SetInteger("State", 0);
        }

               
    }

    
}
