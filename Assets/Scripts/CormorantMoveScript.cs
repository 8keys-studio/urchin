using UnityEngine;
using System.Collections;

public class CormorantMoveScript : MonoBehaviour {

	//object speed
	public Vector2 speed = new Vector2(10, 10);

	// moving direction
	public Vector2 direction = new Vector2(-1, -1);

	private Vector2 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// movement

		if (gameObject.transform.position.y <= 0)
		{
			//to do: make this more elegant
			gameObject.transform.Rotate(0, 0, 270);

			direction.y = 1;
		}

			movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
		
	}

	void FixedUpdate()
	{
		//apply movement to the rigidbody
		GetComponent<Rigidbody2D>().velocity = movement;
	}
}
