using UnityEngine;
using System.Collections;

public class MoveBar : MonoBehaviour 
{
	public float speed;
	public float tilt;

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		var vector = (movement * speed);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (90, 0.0f, vector.x * -tilt);

		/*float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		var vector = (movement * speed);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (90, 0.0f, vector.x * -tilt);*/
	}
}
