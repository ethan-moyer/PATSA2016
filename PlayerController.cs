using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public int speed;
	public int vertSpeed;
	public float AirSpeed;
	private bool Grounded = false;
	public float RaycastCollide;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (Grounded == true)
				rb.AddForce (transform.right * -speed);
			else if (Grounded == false)
				rb.AddForce (transform.right * -AirSpeed);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			if (Grounded == true)
				rb.AddForce (transform.right * speed);
			else if (Grounded == false)
				rb.AddForce (transform.right * AirSpeed);
		}
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down, RaycastCollide);
		if (hit.collider != null) {
			Debug.Log (hit.collider);
			Grounded = true;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && Grounded == true) {
			Grounded = false;
			rb.AddForce(transform.up * vertSpeed);			
		}
		
	}
	void FixedUpdate() {

	}
}
