using UnityEngine;
using System.Collections;

public class OtterMoveScript : MonoBehaviour {

	//object speed
	public Vector2 speed = new Vector2(10, 10);

	// moving direction
	public Vector2 direction = new Vector2(-1, 0);

	private Vector2 movement;
	private float enemyRange;
	public Vector2 setSpeed = new Vector2(); //deprecated - consider removing
	public bool isSitting = false;

	// Use this for initialization
	void Start () {
		setSpeed = speed;
		InvokeRepeating("changeDirection", 0, 0.3f);
	}

	// Update is called once per frame
	void Update () {

		// movement
		//InvokeRepeating("changeDirection", 0, 5f);
		movement = new Vector2(
		speed.x * direction.x,
		speed.y * direction.y);

	}

	void FixedUpdate()
	{
		//apply movement to the rigidbody
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	void changeDirection()
	{
		Vector2 playerPosition = GameObject.Find("Player").transform.position; //get the position of the player

		//if the otter is within 12 horizontal units of the player
		if (((gameObject.transform.position.x - playerPosition.x) < 12)) 
		{
			if (isSitting == false) //if he isn't already in his sitting state...
			{
				isSitting = true; // ... it's time to put him there

				if (gameObject.transform.position.y >= 0) // if he's above the screen midpoint, start with downward momentum...
				{
					direction.y = -1;
				}
				else
				{
					direction.y = 1;  // otherwise start with upward.
				}
			}
			else
			{
				verticalMovement(); //if this isn't the first time we've call this function, offload verticality to its own subroutine
			}

			direction.x = 1; //set otter to move away because he's too close.
			speed.x = setSpeed.x;
			//speed.x = 0;
			//enemyRange = (playerPosition.x + 13);
			//gameObject.transform.position.Set(enemyRange, gameObject.transform.position.y, gameObject.transform.position.z);
		}

		// if the otter is between 12 and 13 horizontal units away from the player
		else if (((gameObject.transform.position.x - playerPosition.x) >= 12) && ((gameObject.transform.position.x - playerPosition.x) <= 13)) 
		{
			if (isSitting == false) //if he isn't already in his sitting state...
			{
				isSitting = true; // ... it's time to put him there

				if (gameObject.transform.position.y >= 0) // if he's above the screen midpoint, start with downward momentum...
				{
					direction.y = -1;
				}
				else
				{
					direction.y = 1; // otherwsie start with upward
				}
			}
			else
			{
				verticalMovement(); //if this isn't the first time we've call this function, offload verticality to its own subroutine
			}

			speed.x = 0; //stop the otter for now - he's in an acceptable threshold of distance
		}

		// if the otter is too far away
		else
		{
			speed.x = setSpeed.x;
			direction.x = -1; //move him toward the player

			if (isSitting == true)
			{
				verticalMovement(); //if this isn't the first time we've call this function, offload verticality to its own subroutine
			}
		}
	}

	void verticalMovement()
	// we want the otter to bounce up and down between Y = 4 and Y= -2
	{
		if (gameObject.transform.position.y >= 4) //if he's at or above Y=4...
		{
			direction.y = -1; //send him down
		}
		else if (gameObject.transform.position.y <= -2) //if he's at or below T = -2...
		{
			direction.y = 1; //send him up
		}
	}
}
