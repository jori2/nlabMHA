using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerActivate : MonoBehaviour {
	[SerializeField] bool isplayer1;
	[SerializeField] bool isplayer2;
	// Update is called once per frame
	void Update () {
		if(isplayer1){
			if (OfflineSceneManager.scenename == "MHAMain2") {
				gameObject.SetActive (false);
			} else {
				gameObject.SetActive (true);
			}
		}

		if(isplayer2){
			if (OfflineSceneManager.scenename == "MHAMain") {
				gameObject.SetActive (false);
			} else {
				gameObject.SetActive (true);
			}
		}
	}
}
