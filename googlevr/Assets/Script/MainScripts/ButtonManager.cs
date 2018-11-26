using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
	[SerializeField] GameObject MHAMain1Button;
	[SerializeField] GameObject MHAMain2Button;
	[SerializeField] GameObject ClientButton;
	void Start(){
		//ClientButton.SetActive (false);
	}
	public void OnPushMHAMainButton(){
		MHAMain1Button.SetActive (false);
		MHAMain2Button.SetActive (false);
		//ClientButton.SetActive (true);
	}
}
