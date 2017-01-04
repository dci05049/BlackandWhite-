using UnityEngine;
using System.Collections;

public class axescript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	public void treefallcontrol () {
		Animator anim = GameObject.Find("sceneanim").GetComponent<Animator> (); 
		anim.SetTrigger("boulder");
	}

	public void axesond () {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play();
	}
}
