using UnityEngine;
using System.Collections;
using System;

[RequireComponent (typeof(MovController))]
[RequireComponent (typeof(LifeControll))]
public class InputController : MonoBehaviour
{
	public float speed = 40f;
	public float forceJump = 10f;

	private bool isRigth;
	private float movX;

	public Transform groundCheck;
	public bool isGround;
	public LayerMask layer;

	private MovController mvC;
	private LifeControll l;


	// Use this for initialization
	void Start ()
	{
		mvC = GetComponent<MovController> ();
		l = GetComponent<LifeControll> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		isGround = Physics2D.OverlapCircle (groundCheck.position, 0.1f, layer);

		movX = Input.GetAxis ("Horizontal");  
		mvC.MovX (movX, speed);

		if (Input.GetButtonDown ("Jump") && isGround) {
			mvC.Jump (forceJump);
		}

		if (isRigth && movX > 0) {
			mvC.Flip ();
			isRigth = false;
		} else if (!isRigth && movX < 0) {
			mvC.Flip ();
			isRigth = true;
		}

		GetComponent <Animator> ().SetFloat ("speed", Math.Abs (movX));
	}
}
