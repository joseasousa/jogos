using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MovController))]
public class IAController : MonoBehaviour
{
	private MovController mvc;
	public Transform groundC;
	private bool isGroung;
	public LayerMask layers;

	public float speed = 1;
	private float x = 1;

	void Start ()
	{
		mvc = GetComponent<MovController> ();
	}


	void Update ()
	{
		isGroung = Physics2D.OverlapCircle (groundC.position, 0.3f, layers);

		mvc.MovX (x, speed);

		if (!isGroung) {
			mvc.Flip ();
			x *= -1;
		}
	}
}
