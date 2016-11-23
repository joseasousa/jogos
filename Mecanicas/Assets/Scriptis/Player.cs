using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public GameObject player;
	public float speed = 3f;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxis("Horizontal") < 0)
		{
			player.transform.position = new Vector2(player.transform.position.x - speed, player.transform.position.y);
			//player.transform.position.x += 2f;
		}
		else if (Input.GetAxis("Horizontal") > 0)
		{
			player.transform.position = 
				new Vector2(player.transform.position.x + speed,
				player.transform.position.y);
			Debug.Log(Input.GetAxis("Horizontal"));
		}
	}
}
