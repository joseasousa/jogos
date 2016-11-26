using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	private float movX = 3;

	public float speed = 40.0f;
	public float forceJump = 300f;

	private bool isRigth;

	private Transform t;

	// Use this for initialization
	void Start ()
	{
		t = GetComponent <Transform> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		movX = Input.GetAxis ("Horizontal");

		Vector2 mov = new Vector2 (movX * speed, 0);

		//GetComponent<Rigidbody2D> ().AddForce (mov);
		GetComponent<Rigidbody2D> ().velocity = mov;

		if (Input.GetButtonDown ("Jump")) {
			//por velociadade
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, forceJump);
			//GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, forceJump));
		}

		if (isRigth && movX > 0) {
			Flip ();
		} else if (!isRigth && movX < 0) {
			Flip ();
		}
	
	}

	void Flip ()
	{
		t.Rotate (new Vector3 (0, 180, 0));
		isRigth = !isRigth;
	}
}
