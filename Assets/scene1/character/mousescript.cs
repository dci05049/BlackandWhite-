using UnityEngine;
using System.Collections;

public class mousescript : MonoBehaviour {
	private boulderscript boulderscript; 
	private bool pickupaxe; 
	private bool pickupmetalpipe; 
	private bool choppedtree = false; 

	private float timer; 

	public AudioClip metalpole;
	public AudioClip axe; 
	public AudioClip tree; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (choppedtree) {
			timer += Time.deltaTime; 
			if (timer > 4) {
				StartCoroutine (ChangeLevel());
				choppedtree = false;
			}
		}
		Vector2 MousePosition = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, +10f));
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.Raycast (MousePosition, Vector2.zero, 5f , 1 << LayerMask.NameToLayer ("Pickups"));
			if (hit.collider != null) {
				if (hit.collider.gameObject.name == "metalpipe") {
					Animator anim = GameObject.Find("sceneanim").GetComponent<Animator> (); 
					anim.SetTrigger("movepipe"); 
					pickupmetalpipe = true; 
					AudioSource audio = GetComponent<AudioSource> ();
					audio.clip = metalpole;
					audio.Play();
				}
				if (hit.collider.gameObject.name == "axe" && pickupmetalpipe) {
					Animator axeanim = GameObject.Find("axe").GetComponent<Animator> (); 
					axeanim.SetTrigger("axepickup"); 
					pickupaxe = true; 
				}

				if (hit.collider.gameObject.name == "tree" && pickupaxe && pickupmetalpipe) {
					Animator anim = GameObject.Find("axe").GetComponent<Animator> (); 
					anim.SetTrigger("axecuttree");
					choppedtree = true; 

				}

			}
		}
	}

	public void bouldercontrol () {
		boulderscript = GameObject.FindObjectOfType<boulderscript> ().GetComponent<boulderscript> (); 
		boulderscript.playanim = true;
	}

	
	public IEnumerator ChangeLevel () {
		GameObject.FindObjectOfType<fade> ().fade_Speed = 0.7f;
		float fadetime = GameObject.FindObjectOfType<fade> ().BeginFade(1);
		yield return new WaitForSeconds(fadetime); 
		Application.LoadLevel ("dialogue2");
	}

	public void playtree () {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = tree;
		audio.Play();
	}
	
}
