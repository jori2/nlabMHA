using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour {
	float fadespeed = 0.02f;
	float red,green,blue,alfa;
	public bool isFadeOut = false;
	public bool isFadeIn = false;

	Image fadeImage;

	[SerializeField] GameObject player;
	PlayerController pc;

	// Use this for initialization
	void Start () {
		fadeImage = GetComponent<Image> ();	
		red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		alfa = fadeImage.color.a;
		pc = player.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(isFadeIn){
			StartFadeIn ();
		}

		if(isFadeOut){
			StartFadeOut ();
		}
	}

	void StartFadeIn(){
		alfa -= fadespeed;
		SetAlpha ();
		if(alfa <= 0){
			isFadeIn = false;
			fadeImage.enabled = false;
		}
	}

	void StartFadeOut(){
		fadeImage.enabled = true;
		alfa += fadespeed;
		SetAlpha ();
		if(alfa >= 1){
			pc.ResetPosition ();
			isFadeOut = false;
		}
	}

	void SetAlpha(){
		fadeImage.color = new Color (red,green,blue,alfa);
	}
}
