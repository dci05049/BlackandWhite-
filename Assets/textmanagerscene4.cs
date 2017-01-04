using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class textmanagerscene4 : MonoBehaviour {
	
	public GameObject textbox; 
	public Text theText;
	
	public TextAsset textfiles; 
	public string[] textlines; 
	
	public int CurrentLine;
	public int EndLine; 
	
	public bool Isactive; 
	
	public bool StopPlayerMovement; 
	private bool IsTyping = false;
	private bool CancelTyping = false; 
	public float TypeSpeed; 
	
	// Use this for initialization
	void Start () {
		if (textfiles != null) {
			textlines = textfiles.text.Split('\n');
		}
		
		if (EndLine == 0) {
			EndLine = textlines.Length - 1;
		}
		
		if (Isactive) {
			EnableTextbox ();
		} else {
			DisableTextbox ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!Isactive) {
			return; 
		}
		
		
	
		
		//theText.text = textlines [CurrentLine]; 
		
		// if the user presses return, move on to the next line; 
		if (Input.GetKeyDown(KeyCode.Return)) {
			if (!IsTyping) {
				
				CurrentLine += 1; 
				
				if (CurrentLine > EndLine) {
					DisableTextbox (); 
				} else {
					StartCoroutine(TextScroll(textlines[CurrentLine]));
				}
			} else if (IsTyping && !CancelTyping) {
				CancelTyping = true; 
			}
			
		}
		
		
		
	}
	
	private IEnumerator TextScroll (string lineoftext) {
		int letter = 0; 
		theText.text = ""; 
		IsTyping = true; 
		CancelTyping = false; 
		while (IsTyping && !CancelTyping && (letter < lineoftext.Length - 1)) {
			theText.text += lineoftext[letter];
			letter += 1; 
			yield return new WaitForSeconds(TypeSpeed); 
		}
		theText.text = lineoftext; 
		IsTyping = false; 
		CancelTyping = false; 
	}
	
	public void EnableTextbox () {
		textbox.SetActive(true);
		Isactive = true; 
		StartCoroutine (TextScroll (textlines [CurrentLine]));
	}
	
	public void DisableTextbox () {
		textbox.SetActive(false);
	}
	
	public void ReloadScript (TextAsset theText) {
		if (theText != null) {
			textlines = new string[1];
			textlines = theText.text.Split('\n');
		}
	}
}