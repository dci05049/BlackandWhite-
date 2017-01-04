using UnityEngine;
using System.Collections;

public class camerascene3 : MonoBehaviour {

	private Vector3 playerposition; 
	public float max; 
	public float min; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		playerposition = GameObject.FindWithTag ("Player").transform.position;
		transform.position = new Vector3 (playerposition.x, playerposition.y +3f, -10f);
		
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, min, max), transform.position.y , -10f);
	}
}
