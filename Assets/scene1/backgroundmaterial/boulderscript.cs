using UnityEngine;
using System.Collections;

public class boulderscript : MonoBehaviour {

	private Animator anim; 
	public bool playanim; 



	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {
		if (playanim) {
			anim.SetTrigger("bouldermove"); 

			}
	}
	public void bouldermove () {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play();
	}
}


