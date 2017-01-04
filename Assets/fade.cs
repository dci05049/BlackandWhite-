using UnityEngine;
using System.Collections;

public class fade : MonoBehaviour {

	public Texture2D fadeout_Texture;//the texture that will overlay the screen 
	public float fade_Speed = 0.6f; //the fading speed of the screen
	
	private int draw_Dept = -1000; //the texture heirarrchy. Lower number means it will be rendered on top
	private float alpha = 1.0f; // the texture's alpha value between 0 and 1
	private int fade_Dir = -1; // the direction to fade -1 to 1
	
	void OnGUI () {
		// fade out/in  the alpha value using a direction, 
		alpha += fade_Dir * fade_Speed * Time.deltaTime; 
		// force (clamp the number between 0 and 1 because gui.colr uses alpha values between 0 and 1
		alpha = Mathf.Clamp01 (alpha);
		
		// set color of our gui 
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha); 
		GUI.depth = draw_Dept; 
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeout_Texture);
	}
	
	public float BeginFade(int direction) {
		fade_Dir = direction; 
		return (fade_Speed);
	}
	
	void OnLevelWasLoaded () {
		BeginFade (-1);
	}
}
