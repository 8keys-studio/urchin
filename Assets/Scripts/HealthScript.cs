using UnityEngine;
using System.Collections;


/// <summary>
/// hitpoints and damage
/// </summary>
public class HealthScript : MonoBehaviour {

	//total hp
	public int hp = 1;
	//enemy or player?
	public bool isEnemy = true;

	/// <summary>
	/// inflicts damage and check if the object should be destroyed
	/// </summary>
	public void Damage(int damageCount)
	{
		hp -= damageCount;

		if (hp <= 0)
		{
			//Particle explosion
			SpecialEffectsHelper.Instance.Explosion(transform.position);

			//Dead
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		//is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			//no friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);

				//Destroy the shot
				Destroy(shot.gameObject); //target game object so we don't remove the script - again ... lol
			}
		}
	}




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
