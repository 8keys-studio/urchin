using UnityEngine;
using System.Collections;

public class JacksMoveScript : MonoBehaviour {

	public float MoveSpeed = 1.0f;

	public float frequency = 3.0f;  // Speed of sine movement
	public float magnitude = 2.0f;   // Size of sine movement
	public float directionAngle = 180.0f;
	public float waveAngle = 90.0f;

	private Vector3 direction;
	private Vector3 wave;

	private Vector3 pos;

	void Start () {
		pos = transform.position;
//		DestroyObject(gameObject, 1.0f);
		direction = GetXYDirection (directionAngle);
		wave = GetXYDirection (waveAngle);
	}

	void Update () {
		pos += direction * Time.deltaTime * MoveSpeed;
		transform.position = pos + wave * Mathf.Sin (Time.time * frequency) * magnitude;
	}

	//Gets an XY direction of magnitude from a radian angle relative to the x axis
	//Simple version
	Vector2 GetXYDirection(float angle) {
		float radian = angle * Mathf.Deg2Rad;
		return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
	}
}