using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    private float movX = 3;

    public float speed = 40f;
    public float forceJump = 10f;

    private bool isRigth;

    private Transform t;

    private Rigidbody2D rb;
    public Transform groundCheck;
    public bool isGround;

    public LayerMask layer;

    public Text scoreM;
    private int score;
    public AudioClip sound;
    private AudioSource audio;

    public GameObject pedra;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, layer);

        movX = Input.GetAxis("Horizontal");  
        rb.velocity = new Vector2(movX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGround)
        {
            rb.velocity = new Vector2(0, forceJump);		
        }

        if (isRigth && movX > 0)
        {
            Flip();
        }
        else if (!isRigth && movX < 0)
        {
            Flip();
        }

        GetComponent <Animator>().SetFloat("speed", Math.Abs(movX));
    }

    void Flip()
    {
        transform.Rotate(new Vector3(0, 180, 0));
        isRigth = !isRigth;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "portal")
        {
            transform.position = new Vector3(56.5f, 0, 0);    
        }
        else if (other.tag == "death")
        {
            transform.position = new Vector3(0, 0, 0);     
        }
        else if (other.tag == "coin")
        {
            Destroy(other.gameObject);
            scoreM.text = "Score: " + score;
            score += 10;

            audio.clip = sound;
            audio.Play();
        }
        else if (other.tag == "trap")
        {
            Instantiate(pedra, new Vector3(other.transform.position.x, other.transform.position.y, 0), Quaternion.identity);
            pedra.GetComponent<Rigidbody2D>().AddForce(new Vector2(800000, 0));
        }
       

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "des")
        {
            Destroy(col.gameObject);
        }
    }

}
