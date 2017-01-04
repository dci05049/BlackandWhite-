using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class TextBoxManager : MonoBehaviour {
	
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

		
		if (CurrentLine == 10 && Application.loadedLevelName == "dialogue1") {
			StartCoroutine (ChangeLevel());
		}

		if (CurrentLine == 6 && Application.loadedLevelName == "dialogue2") {
			StartCoroutine (ChangeLevel2());
		}

		if (CurrentLine == 8 && Application.loadedLevelName == "dialogue3") {
			StartCoroutine (ChangeLevel3());
		}

		if (CurrentLine == 9 && Application.loadedLevelName == "dialogue4") {
			StartCoroutine (ChangeLevel4());
		}

		if (CurrentLine == 4 && Application.loadedLevelName == "dialogue5") {
			StartCoroutine (ChangeLevel5());
		}

		if (CurrentLine == 3 && Application.loadedLevelName == "dialogue6") {
			StartCoroutine (ChangeLevel6());
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

	IEnumerator ChangeLevel () {
		GameObject.FindObjectOfType<fade> ().fade_Speed = 0.7f;
		float fadetime = GameObject.FindObjectOfType<fade> ().BeginFade(1);
		yield return new WaitForSeconds(fadetime); 
		Application.LoadLevel ("blackwhite");
	}

	IEnumerator ChangeLevel2 () {
		GameObject.FindObjectOfType<fade> ().fade_Speed = 0.7f;
		float fadetime = GameObject.FindObjectOfType<fade> ().BeginFade(1);
		yield return new WaitForSeconds(fadetime); 
		Application.LoadLevel ("blackwhite 2");
	}
	IEnumerator ChangeLevel3 () {
		GameObject.FindObjectOfType<fade> ().fade_Speed = 0.7f;
		float fadetime = GameObject.FindObjectOfType<fade> ().BeginFade(1);
		yield return new WaitForSeconds(fadetime); 
		Application.LoadLevel ("blackwhite3");
	}
	IEnumerator ChangeLevel4 () {
		GameObject.FindObjectOfType<fade> ().fade_Speed = 0.7f;
		float fadetime = GameObject.FindObjectOfType<fade> ().BeginFade(1);
		yield return new WaitForSeconds(fadetime); 
		Application.LoadLevel ("blackwhite4");
	}

	IEnumerator ChangeLevel5 () {
		GameObject.FindObjectOfType<fade> ().fade_Speed = 0.7f;
		float fadetime = GameObject.FindObjectOfType<fade> ().BeginFade(1);
		yield return new WaitForSeconds(fadetime); 
		Application.LoadLevel ("blackwhite5");
	}

	IEnumerator ChangeLevel6 () {
		GameObject.FindObjectOfType<fade> ().fade_Speed = 0.7f;
		float fadetime = GameObject.FindObjectOfType<fade> ().BeginFade(1);
		yield return new WaitForSeconds(fadetime); 
		Application.LoadLevel ("blackwhite6");
	}
}

