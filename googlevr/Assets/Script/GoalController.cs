using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoalController : NetworkBehaviour {
	public static bool Isgoal;
	int colorvalue;
	void Start(){
		colorvalue = 0;
		Isgoal = false;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider){
		if(!isLocalPlayer){
			return;
		}
			if(Isgoal == false){
				if(collider.gameObject.tag == ("Player")){
					colorvalue = 1;
					CmdGoal (colorvalue);
				}
				if(collider.gameObject.tag == ("Player2")){
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
		GoalDoor (colorval);
	}

	void GoalDoor(int colorval){
		Isgoal = true;
		if(colorval == 1){
			GetComponent<Renderer> ().material.color = Color.red;
		}else if(colorval == 2){
			GetComponent<Renderer> ().material.color = Color.blue;
		}
	}
}
