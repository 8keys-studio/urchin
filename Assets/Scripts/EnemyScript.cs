using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	/// <summary>
	/// Enemy generic behavior
	/// </summary>

	private WeaponScript weapon;

	void Awake () {
		//retrieve the weapon only once
		weapon = GetComponent<WeaponScript>();

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//auto-fire
		if (weapon != null && weapon.CanAttack)
		{
			weapon.Attack(true);
		}

	}
}
