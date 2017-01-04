using UnityEngine;
using System.Collections;

public class turnsblack : MonoBehaviour {
	private darkground darkgroundscript; 
	private float changetime = 1f; 
	private float timer; 

	private Animator anim;
	public Sprite blackball; 
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {
		darkgroundscript = GameObject.FindObjectOfType<darkground> ().GetComponent<darkground> (); 
		if (darkgroundscript.whiteballin) {
			timer += Time.deltaTime; 
			if (timer > changetime) {
				anim.SetTrigger("black"); 
			}
		}
	}
}
