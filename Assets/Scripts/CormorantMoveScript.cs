using UnityEngine;
using System.Collections;

public class CormorantMoveScript : MonoBehaviour {

	//object speed
	public Vector2 speed = new Vector2(10, 10);

	// moving direction
	public Vector2 direction = new Vector2(-1, -1); // the cormorant begins by diving

	private Vector2 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// movement

		//if the cormorant has reached mid screen height and hasn't been rotated yet
		if ((gameObject.transform.position.y <= 0) && (gameObject.transform.rotation.z != 270))
		{
			//to do: make this more elegant
			//to do: this intermittently causes the enemy to set z-rotation to 180?? Find out if there's a better way to handle this, or 
			//just fix it with animations.
			gameObject.transform.Rotate(0, 0, 270); //rotate him to be pointed at the surface

			direction.y = 1; //reverse his direction to up
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
