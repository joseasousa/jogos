using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;

public class PlayerController : MonoBehaviour
{
    private float movX = 3;

    public float speed = 40.0f;
    public float forceJump = 300f;

    private bool isRigth;

    private Transform t;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        t = GetComponent <Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            movX = Input.GetAxis("Horizontal");  
            rb.velocity = new Vector2(movX * speed, 0);
        }	

        if (Input.GetButtonDown("Jump"))
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