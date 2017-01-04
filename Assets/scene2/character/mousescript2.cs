using UnityEngine;
using System.Collections;

public class mousescript2 : MonoBehaviour {
	private bool shovelpickup; 
	public Sprite dirtpicked; 
	public bool waterflow; 

	public AudioClip water;
	public AudioClip dirtpick; 
	public AudioClip shovel; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 MousePosition = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, +10f));
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.Raycast (MousePosition, Vector2.zero, 5f , 1 << LayerMask.NameToLayer ("dirt")  | 1 << LayerMask.NameToLayer ("Pickups"));
			if (hit.collider != null) {
				Debug.Log("hitsomething"); 
				if (hit.collider.gameObject.name == "shovelcol") {
					Destroy(hit.collider.transform.parent.gameObject); 
					shovelpickup = true; 
					AudioSource audio = GetComponent<AudioSource> ();
					audio.clip = shovel;
					audio.Play();
				}

				if (hit.collider.gameObject.tag == "dirt" && shovelpickup) {
					Destroy(hit.collider); 
					SpriteRenderer spriterenderer = hit.collider.gameObject.GetComponent<SpriteRenderer> (); 
					spriterenderer.sprite = dirtpicked; 
					AudioSource audio = GetComponent<AudioSource> ();
					audio.clip = dirtpick;
					audio.Play();
				}

				if (hit.collider.gameObject.name == "lastdirt") {
					AudioSource audio = GetComponent<AudioSource> ();
					audio.clip = water;
					audio.Play();
					waterflow = true; 
				}
			}
		}
	}
}
