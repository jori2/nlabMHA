using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour {
	private AudioSource sound1;

	void Start(){
		AudioSource[] audioSource = GetComponents<AudioSource> ();
		sound1 = audioSource [0];
	}

	public void OnButtonEnter(){
		sound1.PlayOneShot (sound1.clip);
	}
}
