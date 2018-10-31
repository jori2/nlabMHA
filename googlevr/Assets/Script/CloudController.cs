using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {
	private int scalecount;
	GameObject player;
	void Start(){
		scalecount = 0;
		player = GameObject.FindWithTag("Player");
	}

	void Update () {
		//BillBoard
		if (player != null) {
			transform.LookAt (player.transform.position);
		}
		if(scalecount<=10){
			gameObject.transform.localScale = new Vector3(0.01f * scalecount,0.01f * scalecount,0.01f * scalecount);
			scalecount++;
		}
	}
}
