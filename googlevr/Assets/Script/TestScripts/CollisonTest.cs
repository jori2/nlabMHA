using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonTest : MonoBehaviour {


	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.CompareTag("Player")){
			Debug.Log ("enter");
		}
	}

	void Update(){
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.position = new Vector3 (transform.position.x+0.1f,transform.position.y,transform.position.z);
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.position = new Vector3 (transform.position.x-0.1f,transform.position.y,transform.position.z);
		}
		if(Input.GetKey(KeyCode.UpArrow)){
			transform.position = new Vector3 (transform.position.x,transform.position.y,transform.position.z+0.1f);
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			transform.position = new Vector3 (transform.position.x,transform.position.y,transform.position.z-0.1f);
		}
	}
}
