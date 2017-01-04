using UnityEngine;
using System.Collections;

public class darkground : MonoBehaviour {
	public Sprite dirtpicked; 
	public bool whiteballin; 	

	private float changetime = 1f; 
	private float timer; 

	private SpriteRenderer spriterender; 
	private float changeleveltimer; 

	// Use this for initialization
	void Start () {
		spriterender = GetComponent<SpriteRenderer> (); 
	}
	
	// Update is called once per frame
	void Update () {

		if (whiteballin) {
			timer += Time.deltaTime; 
			if (timer > changetime) {
				spriterender.sprite = null; 
			}
			changeleveltimer += Time.deltaTime; 
			if (changeleveltimer > 3) {
				StartCoroutine (ChangeLevel());
			}
		}
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.name == "colider") {
			whiteballin = true; 
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play();
		}
	}

	public IEnumerator ChangeLevel () {
		GameObject.FindObjectOfType<fade> ().fade_Speed = 0.7f;
		float fadetime = GameObject.FindObjectOfType<fade> ().BeginFade(1);
		yield return new WaitForSeconds(fadetime); 
		Application.LoadLevel ("dialogue4");
	}

}
