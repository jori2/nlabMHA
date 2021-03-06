﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CreateCloud : NetworkBehaviour {
	public GameObject mutualobject;
	public GameObject cloudinstance;
	private GameObject player;
	NetworkConnection conn;
	Vector3 worldPos;
	//脳波計
	private int currentAtt;
	GameManagerController gm;
	void Start(){
		
		if(SceneManager.GetActiveScene().name == "MHAMain2"){
			gameObject.GetComponent<MeshCollider> ().enabled = false;
		}

		gm = GameObject.FindWithTag("GM").GetComponent<GameManagerController>();
		//gameObject.GetComponent<NetworkIdentity> ().AssignClientAuthority (conn);
		//player = GameObject.FindWithTag ("Player")
//		if (OfflineSceneManager.scenename == "MHAMain") {
//			gameObject.SetActive (true);
//		} else {
//			gameObject.SetActive (false);
//		}
	}

	public void Createcloud(BaseEventData data){
//		if(!isLocalPlayer){
//			return;
//		}
		player = GameObject.FindWithTag("Player");
//		if(player.GetComponent<PlayerController> ().isCharge == true){
			PointerEventData pointerData = data as PointerEventData;
			worldPos = pointerData.pointerCurrentRaycast.worldPosition;
			Debug.Log (worldPos);
			//player.GetComponent<PlayerController>().CallSpawnMethod (cloudinstance);
			CmdInstanceCloud(worldPos);
			player.GetComponent<PlayerController> ().isCharge = false;
			gm.Setcreatecount ();
//		}
	}

	[Command]
	void CmdInstanceCloud(Vector3 pos){
		cloudinstance =(GameObject)Instantiate (mutualobject,pos,Quaternion.identity);
		NetworkServer.Spawn (cloudinstance);
	}

//	void Update (){

//		if (OfflineSceneManager.scenename = "MHAMain") {
//			gameObject.SetActive (true);
//		} else {
//			gameObject.SetActive (false);
//		}
//		if(SceneManager.GetActiveScene().name == "MHAMain2"){
//			gameObject.SetActive (false);
//		}
//	}

	
}
