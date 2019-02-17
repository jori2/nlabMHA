using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScreenShot : MonoBehaviour {
	float fadespeed = 0.05f;
	float red,green,blue,alfa;
	public bool isFadeOut = false;
	public bool isFadeIn = false;
	[SerializeField] Material MHA;
	[SerializeField] SpriteRenderer SR;

	void Start(){
		red = MHA.color.r;
		green = MHA.color.g;
		blue = MHA.color.b;
		alfa = MHA.color.a;
	}

	void Update(){
		if(isFadeIn){
			StartFadeInMHA ();
		}

		if(isFadeOut){
			StartFadeOutMHA ();
		}
	}

	public void StartFadeInMHA(){
		alfa -= fadespeed;
		SetAlpha ();
		if(alfa <= 0){
			isFadeIn = false;
			SR.enabled = false;
		}
	}

	public void StartFadeOutMHA(){
		SR.enabled = true;
		alfa += fadespeed;
		SetAlpha ();
		if(alfa >= 1){
			isFadeOut = false;
		}
	}

	void SetAlpha(){
		MHA.color = new Color (red,green,blue,alfa);
	}

	public void SetIsFadeOut(){
		isFadeIn = false;
		isFadeOut = true;
	}

	public void SetIsFadeIn(){
		isFadeOut = false;
		isFadeIn = true;
	}
}
