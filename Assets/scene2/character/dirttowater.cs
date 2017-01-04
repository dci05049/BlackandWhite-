using UnityEngine;
using System.Collections;

public class dirttowater : MonoBehaviour {
	private mousescript2 gamecontrolscript; 
	public Sprite watersprite; 
	public float changetime; 
	private float timer; 

	private bool changelevel; 
	private float timerchangelevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		gamecontrolscript = GameObject.FindObjectOfType<mousescript2> ().GetComponent<mousescript2> ();
		if (gamecontrolscript.waterflow) {
			timer += Time.deltaTime; 
			if (timer > changetime) {
			SpriteRenderer spriterenderer = GetComponent<SpriteRenderer> (); 
			spriterenderer.sprite = watersprite; 
				if (gameObject.name == "dirtchangelevel") {
					GetComponent<changelevel> ().changescene = true; 
				}
			}
		}

	

	}



}
