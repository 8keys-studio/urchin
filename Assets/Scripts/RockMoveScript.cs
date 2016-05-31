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

		// set direction of the rock to aim at the player. We set this when the rock is generated because its direction is never altered.
		Vector2 playerPosition = GameObject.Find("Player").transform.position;

		//get the change in Y between the instance and destination, over speed and make it negative for proper results.
		direction.y = (((gameObject.transform.position.y - playerPosition.y) / speed.y) * -1);

	}
	
	// Update is called once per frame
	void Update () {

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
