using UnityEngine;
using System.Collections;

public class LastScene : MonoBehaviour {
	private float time;
	private bool changescene = false; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime; 
		if (time >= 5 && !changescene) {
			StartCoroutine (ChangeLevel ());
			changescene = true; 
		}
	}

	public IEnumerator ChangeLevel () {
		GameObject.FindObjectOfType<fade> ().fade_Speed = 0.7f;
		float fadetime = GameObject.FindObjectOfType<fade> ().BeginFade(1);
		yield return new WaitForSeconds(fadetime); 
		Application.LoadLevel ("endscene");
	}
}
