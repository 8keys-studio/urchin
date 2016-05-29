using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	/// <summary>
	/// Enemy generic behavior
	/// </summary>

	private WeaponScript[] weapons;

	void Awake () {
		//retrieve the weapon only once
		weapons = GetComponentsInChildren<WeaponScript>();

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		foreach (WeaponScript weapon in weapons)
		{
			//auto-fire
			if (weapon != null && weapon.CanAttack)
			{
				weapon.Attack(true);
			}
		}
	}
}
