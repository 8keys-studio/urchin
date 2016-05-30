using UnityEngine;
using System.Collections;

public class OtterMoveScript : MonoBehaviour {

	//object speed
	public Vector2 speed = new Vector2(10, 10);

	// moving direction
	public Vector2 direction = new Vector2(-1, 0);

	private Vector2 movement;
	private float enemyRange;
	public Vector2 setSpeed = new Vector2();
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
		Vector2 playerPosition = GameObject.Find("Player").transform.position;

		if (((gameObject.transform.position.x - playerPosition.x) < 12))
		{
			if (isSitting == false)
			{
				isSitting = true;
			}

			direction.x = 1;
			speed.x = setSpeed.x;
			//speed.x = 0;
			//enemyRange = (playerPosition.x + 13);
			//gameObject.transform.position.Set(enemyRange, gameObject.transform.position.y, gameObject.transform.position.z);
		}

		else if (((gameObject.transform.position.x - playerPosition.x) >= 12) && ((gameObject.transform.position.x - playerPosition.x) <= 13))
		{
			if (isSitting == false)
			{
				isSitting = true;
			}

			speed.x = 0;
		}

		else
		{
			speed.x = setSpeed.x;
			direction.x = -1;
		}
	}
}
