using UnityEngine;
using System.Collections;

public class playermove : MonoBehaviour {
	public int speed; 
	private Rigidbody2D body2d; 
	private Animator anim;
	public bool meetwhiteball; 

	public bool facingRight; 


	// Use this for initialization
	void Start () {
		body2d = GetComponent<Rigidbody2D> (); 
		anim = GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxisRaw ("Horizontal"); 
		body2d.velocity = new Vector2 (h * speed, body2d.velocity.y);

		if (h > 0 && !facingRight)
			// ... flip the player.
			Flip ();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (h < 0 && facingRight)
			// ... flip the player.
			Flip ();
	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.name == "whitecolider") {
			meetwhiteball = true; 
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.name == "house1") {

		}
	}
}
