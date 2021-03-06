﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	/// <summary>
	/// ship speed
	/// </summary>
	public Vector2 speed = new Vector2(50, 50);

	// store the movement
	private Vector2 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// retrieve axis info
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		// movement per direction
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);

		// 5 - Shooting
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		// Careful: For Mac users, ctrl + arrow is a bad idea

		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// false because the player is not an enemy
				weapon.Attack(false);
			}
		}

		// 6 - Make sure we are not outside the camera bounds
		var dist = (transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
		).x;

		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
		).x;

		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
		).y;

		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
		).y;

		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
		);
	}

	void FixedUpdate()
	{
		//move the game object
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		bool damagePlayer = false;

		//Collision with enemy types - there's probably a cleaner way to do this
		EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
		OtterEnemyScript otterEnemy = collision.gameObject.GetComponent<OtterEnemyScript>();
		CormorantEnemyScript cormorantEnemy = collision.gameObject.GetComponent<CormorantEnemyScript>();

		if (enemy != null)
		{

			HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
			if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);

			damagePlayer = true;

		}

		if (otterEnemy != null)
		{

			HealthScript enemyHealth = otterEnemy.GetComponent<HealthScript>();
			if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);

			damagePlayer = true;

		}

		if (cormorantEnemy != null)
		{

			HealthScript enemyHealth = cormorantEnemy.GetComponent<HealthScript>();
			if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);

			damagePlayer = true;

		}



		// Damage the player

		if (damagePlayer)
		{
			HealthScript playerHealth = this.GetComponent<HealthScript>();
			if (playerHealth != null) playerHealth.Damage(1);
		}


	}

	void OnDestroy()
	{
		//Fire the Game Over screen on death
		//TO DO: call another script and wait a few frames before game over to give time for explosion to fire
		Application.LoadLevel("GameOver");
	}

}
