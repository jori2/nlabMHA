using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {
	float time;
	float DWscale;
	[SerializeField] GameObject  target;
	void Start(){
		time = 0;
		DWscale = 0.05f;
		target = GameObject.FindWithTag ("Subcamera");
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		transform.LookAt (target.transform.position);
		if(time >= 4){
			Destroy (gameObject);
		}else if(time >= 2){
			gameObject.transform.localScale = new Vector3 (DWscale / (1 + (time-2)*(time-2)*(time-2)*(time-2)), DWscale / (1 + (time-2)*(time-2)*(time-2)*(time-2)), DWscale / (1 + (time-2)*(time-2)*(time-2)*(time-2)));
		}
	}
}
