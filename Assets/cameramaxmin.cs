using UnityEngine;
using System.Collections;

public class cameramaxmin : MonoBehaviour {
	private Vector3 playerposition; 
	public float max; 
	public float min; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		playerposition = GameObject.FindWithTag ("Player").transform.position;
		transform.position = new Vector3 (playerposition.x, playerposition.y + 3f, -10f);
		
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, min, max),Mathf.Clamp (transform.position.y, 1.74f, 50f) , -10f);
	}
}
