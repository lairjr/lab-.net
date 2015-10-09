using UnityEngine;
using System.Collections;

public class TableController : MonoBehaviour {
	float time;
	float totalDistance;
	Vector3 posA, posB;
	bool isMovingRight;

	public float speed;

	// Use this for initialization
	void Start () {
		time = Time.time;

		posA = new Vector3 (4f, 4f, -3f);
		posB = new Vector3 (-4f, 4f, -3f);
	}
	
	// Update is called once per frame
	void Update () {
		float curDuration = (Time.time - time) * speed;
		float journey = curDuration;

		if (isMovingRight)
			transform.position = Vector3.Lerp (posA, posB, journey);
		else
			transform.position = Vector3.Lerp (posB, posA, journey);
		
		if (transform.position == posB) {
			isMovingRight = true;
			time = Time.time;
		}
		if (transform.position == posA) {
			isMovingRight = false;
			time = Time.time;
		}
	}
}
