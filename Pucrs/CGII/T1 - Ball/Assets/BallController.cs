using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;

public class BallController : MonoBehaviour {	

	public int Speed;
	public Text countText;
	public Text timeText;

	private Stopwatch clock;
	private int Points;
	private int Phase;
	private Rigidbody rb;
	private bool canGoNextPhase;


	// Use this for initialization
	void Start () {		
		this.rb = GetComponent<Rigidbody> ();
		this.Points = 0;
		SetCountText ();
		clock = new Stopwatch ();
		clock.Start ();
		Phase = 2;
		canGoNextPhase = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Return)) { 
			this.transform.position = new Vector3(0f, 0.5f, 8f);
			this.rb.velocity = Vector3.zero;
			this.rb.angularVelocity = Vector3.zero;
		}

		if (Input.GetKey (KeyCode.P) && canGoNextPhase) {
			canGoNextPhase = false;
			this.transform.position = new Vector3(0f, 0.5f, 8f);
			this.rb.velocity = Vector3.zero;
			this.rb.angularVelocity = Vector3.zero;

			this.clock = new Stopwatch();
			clock.Start ();
			this.Phase += 2;
			this.Points = 0;
			SetCountText();
		}

		if (this.clock.ElapsedMilliseconds >= 30000) {
			timeText.text = "Tempo esgotado!";
			canGoNextPhase = true;
			if (this.Points >= this.Phase) {
				if (this.Phase == 10) {
					timeText.text = "Parabens voce fechou todos os niveis!";
				} else {
					timeText.text = "Voce venceu! Precione P para proxima fase.";
				}
			}
			else {
				timeText.text = "Tempo esgotado! Voce perdeu.";
			}
		} else {
			SetTimeText ();
		}
	}

	public bool IsMoving() {
		return this.rb.velocity.magnitude > 0;
	}

	void FixedUpdate(){
		if (Input.GetKey (KeyCode.Space)) {
			var movement = new Vector3 (0f, 3f, -2);
			this.rb.AddForce (movement * Speed);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ( "Target"))
		{
			this.Points += 1;
			SetCountText();
		}
	}

	void SetCountText() {
		countText.text = string.Format ("Points: {0}/{1}", this.Phase, this.Points);
	}

	void SetTimeText() {
		timeText.text = string.Format ("Time: 30/{0}", this.clock.ElapsedMilliseconds / 1000);
	}
}
