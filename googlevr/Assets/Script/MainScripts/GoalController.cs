﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoalController : NetworkBehaviour {
	public static bool Isgoal;
	int colorvalue;
	GameObject goaltext;
	void Start(){
		DontDestroyOnLoad (gameObject);
		colorvalue = 0;
		Isgoal = false;
		goaltext = GameObject.FindWithTag ("GoalText");
	}

	void OnCollisionEnter(Collision collision){
		Debug.Log ("enter!");
		if(Isgoal == false){
			if(collision.gameObject.tag == "Player"){
					colorvalue = 1;
					Debug.Log ("player1enter!");
					CmdGoal (colorvalue);
				}
			if(collision.gameObject.tag == "Player2"){
					colorvalue = 2;
					CmdGoal (colorvalue);
				}
		}
	}

	[Command]
	void CmdGoal(int colorval){
		RpcGoal (colorval);
	}

	[ClientRpc]
	void RpcGoal(int colorval){
		Debug.Log ("Rpc!");
		GoalDoor (colorval);
	}

	void GoalDoor(int colorval){
		Isgoal = true;
		if(colorval == 1){
			GetComponent<Renderer> ().material.color = Color.red;
			goaltext.GetComponent<GoalTextController> ().SetPlayerNumber (1);
		}else if(colorval == 2){
			GetComponent<Renderer> ().material.color = Color.blue;
			goaltext.GetComponent<GoalTextController> ().SetPlayerNumber (2);
		}
	}
}
