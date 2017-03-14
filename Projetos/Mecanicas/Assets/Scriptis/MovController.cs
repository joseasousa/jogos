using UnityEngine;
using System.Collections;

public class MovController : MonoBehaviour
{
	private Rigidbody2D rb2d;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	public void MovX (float x, float speed)
	{
		rb2d.velocity = new Vector2 (x * speed, rb2d.velocity.y);
	}

	public void Jump (float force)
	{
		rb2d.velocity = new Vector2 (0, force);	
	}

	public void Flip ()
	{
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
