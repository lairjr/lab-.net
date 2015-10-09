using UnityEngine;
using System.Collections;

public class BarController : MonoBehaviour {

	Vector3 posFinal;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ChangePostion ();
	}

	void ChangePostion() {
		var pos1 = new Vector3 (1, 1, 0);
		var pos2 = new Vector3 (-1, -1, 0);
		var rotation = 90;

		if (Input.GetKey (KeyCode.D))
			posFinal = pos1;

		var newAngles = rotation * Vector3.left;
		this.transform.position = Vector3.Lerp (this.transform.position, posFinal, 12f * Time.deltaTime);
	}
}
