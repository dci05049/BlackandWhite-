using UnityEngine;
using System.Collections;

public class changelevel : MonoBehaviour {
	public bool changescene; 
	private float timer; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (changescene) {
			timer += Time.deltaTime; 
			if (timer > 2) {
				StartCoroutine (ChangeLevel());
				changescene = false;
			}
		}
	}

	
	public IEnumerator ChangeLevel () {
		GameObject.FindObjectOfType<fade> ().fade_Speed = 0.7f;
		float fadetime = GameObject.FindObjectOfType<fade> ().BeginFade(1);
		yield return new WaitForSeconds(fadetime); 
		Application.LoadLevel ("dialogue3");
	}
}
