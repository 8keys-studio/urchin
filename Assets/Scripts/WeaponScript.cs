using UnityEngine;
using System.Collections;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour {

	//projectile prefab
	public Transform shotPrefab;

	//cooldown btw shots
	public float shootingRate = 0.25f;

	private float shootCooldown;

	// Use this for initialization
	void Start () {

		shootCooldown = 0f;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}

	}

	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;

			//create new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;

			//Assign Position
			shotTransform.position = transform.position;

			//The is enemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}

			//Make the weapon shot always towards it
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null)
			{
				move.direction = this.transform.right; //towards in 2d space is the right of the sprite
			}
		}
	}

	//is the weapon ready to create a new projectile?
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}
