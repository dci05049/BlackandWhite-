using UnityEngine;
using System.Collections;

public class animatoractive : MonoBehaviour {
	private playermove playermainscript; 

	private Animator anim; 
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {
		playermainscript = GameObject.FindObjectOfType<playermove> ().GetComponent<playermove> (); 
		if (playermainscript.meetwhiteball) {
			anim.enabled = true; 
		}
	}

	public void starsound () {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play();
	}
}
