using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {
	private int scalecount;
	void Start(){
		scalecount = 0;
	}

	void Update () {
		//BillBoard
		GameObject player = GameObject.FindWithTag("Player");
		if (player != null) {
			transform.LookAt (player.transform.position);
		}
		if(scalecount<=10){
			gameObject.transform.localScale = new Vector3(0.01f * scalecount,0.01f * scalecount,0.01f * scalecount);
			scalecount++;
		}
	}
}
