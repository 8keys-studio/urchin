using UnityEngine;
using System.Collections;

public class RockMoveScript : MonoBehaviour {

	//object speed
	public Vector2 speed = new Vector2(10, 10);

	// moving direction
	public Vector2 direction = new Vector2(-1, 0);

	private Vector2 movement;


	// Use this for initialization
	void Start () {
	
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}
	
	// Update is called once per frame
	void Update () {

		if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
		{
			Destroy(gameObject);
		}
	
	}

	void FixedUpdate()
	{
		//apply movement to the rigidbody
		GetComponent<Rigidbody2D>().velocity = movement;
	}
}
