using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GoalController : NetworkBehaviour {
	public static bool Isgoal;
	[SerializeField] bool isplayer1;
	[SerializeField] bool isplayer2;
	int colorvalue;
	[SerializeField] GameObject goaltext;
	void Start(){
		if(SceneManager.GetActiveScene().name == "MHAMain" && gameObject.tag == "Goal2"){
			gameObject.GetComponent<BoxCollider> ().enabled = false;
		}else if(SceneManager.GetActiveScene().name == "MHAMain2" && gameObject.tag == "Goal"){
			gameObject.GetComponent<BoxCollider> ().enabled = false;
		}
		//DontDestroyOnLoad (gameObject);
		colorvalue = 0;
		Isgoal = false;

	}

	void OnCollisionEnter(Collision collision){
		if (isplayer1) {
			Debug.Log ("enter!");
			if (Isgoal == false) {
				if (collision.gameObject.tag == "Player") {
					colorvalue = 1;
					Debug.Log ("player1enter!");
					CmdGoal (colorvalue);
				}
			}
		}
		if(isplayer2){
			Debug.Log ("enter!");
			if (Isgoal == false) {
				if(collision.gameObject.tag == "Player2"){
						colorvalue = 2;
						CmdGoal (colorvalue);
				}
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
			//ゴールテキストの検索
			if(SceneManager.GetActiveScene().name == "MHAMain"){
				goaltext = GameObject.FindWithTag ("GoalText");
			}else if(SceneManager.GetActiveScene().name == "MHAMain2"){
				goaltext = GameObject.FindWithTag ("GoalText2");
			}
			goaltext.GetComponent<GoalTextController> ().SetPlayerNumber (1);
		}else if(colorval == 2){
			GetComponent<Renderer> ().material.color = Color.blue;
			//ゴールテキストの検索
			if(SceneManager.GetActiveScene().name == "MHAMain"){
				goaltext = GameObject.FindWithTag ("GoalText");
			}else if(SceneManager.GetActiveScene().name == "MHAMain2"){
				goaltext = GameObject.FindWithTag ("GoalText2");
			}
			goaltext.GetComponent<GoalTextController> ().SetPlayerNumber (2);
		}
	}
}
