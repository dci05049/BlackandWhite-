using UnityEngine;
using System.Collections;

public class activatetextatline : MonoBehaviour {

	public TextAsset theText; 
	
	public int startLine; 
	public int endLine; 
	public TextBoxManager textboxmanager; 
	
	public bool DestroyWhenActicated; 
	// Use this for initialization
	void Start () {
		textboxmanager = FindObjectOfType<TextBoxManager> (); 
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "colider") {
			textboxmanager.ReloadScript(theText);
			textboxmanager.CurrentLine = startLine;
			textboxmanager.EndLine = endLine; 
			textboxmanager.EnableTextbox (); 
			
			if (DestroyWhenActicated) {
				Destroy(gameObject);
			}
		}
	}
	
}
