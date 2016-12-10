using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;

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

    // Use this for initialization
    void Start()
    {
        t = GetComponent <Transform>();
        rb = GetComponent<Rigidbody2D>();
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
        t.Rotate(new Vector3(0, 180, 0));
        isRigth = !isRigth;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "portal")
        {
            t.position = new Vector3(56.5f, 0, 0);    
        }
        else if (other.tag == "death")
        {
            t.position = new Vector3(0, 0, 0);     
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
