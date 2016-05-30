using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {
	/// <summary>
	/// Projectile behavior
	/// </summary>

	//amount damage inflicted
	public int damage = 1;

	//damage player on hit?
	public bool isEnemyShot = false;

	// Use this for initialization
	void Start () {

		//shot lives for limited time to avoid any leak
		Destroy(gameObject, 20); // 20 sec
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
		{
			Destroy(gameObject);
		}
	
	}
}
