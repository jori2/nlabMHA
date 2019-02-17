using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
	[SerializeField] GameObject MHAMain1Button;
	[SerializeField] GameObject MHAMain2Button;
	[SerializeField] GameObject ClientButton;

//	private AudioSource sound2;
	void Start(){
		//ClientButton.SetActive (false);
//		sound2 = audioSource [1];
	}
	public void OnPushMHAMainButton(){
		MHAMain1Button.SetActive (false);
		MHAMain2Button.SetActive (false);
		//ClientButton.SetActive (true);
	}



//	public void OnPushButton(){
//		sound2.PlayOneShot (sound2.clip);
//	}
}
