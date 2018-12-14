using System.Collections;
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
	void Start(){
		if(SceneManager.GetActiveScene().name == "MHAMain2"){
			gameObject.GetComponent<MeshCollider> ().enabled = false;
		}
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
		bool Charge = player.GetComponent<PlayerController> ().isCharge;
		if(Charge == true){
			PointerEventData pointerData = data as PointerEventData;
			worldPos = pointerData.pointerCurrentRaycast.worldPosition;
			Debug.Log (worldPos);
			//player.GetComponent<PlayerController>().CallSpawnMethod (cloudinstance);
			CmdInstanceCloud(worldPos);
			Charge = false;
		}
	}

	[Command]
	void CmdInstanceCloud(Vector3 pos){
		cloudinstance =(GameObject)Instantiate (mutualobject,pos,Quaternion.identity);
		NetworkServer.Spawn (cloudinstance);
	}

//	void Update (){
//
//		if (OfflineSceneManager.scenename = "MHAMain") {
//			gameObject.SetActive (true);
//		} else {
//			gameObject.SetActive (false);
//		}
//	}
}
