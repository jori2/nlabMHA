using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {
	[SerializeField] GameObject goalPrefab;
	[SerializeField] GameObject gmPrefab;
	[SerializeField] bool isplayer1;
	[SerializeField] bool isplayer2;
	[SerializeField] GameObject phychicEffect;
	private int currentAtt;
		
	void Start(){
		if (!isLocalPlayer) {
			return;
		}
		if(SceneManager.GetActiveScene().name == "MHAMain"){
			CmdSpawnGoal ();
			CmdSpawnGameManager ();
		}
		//effectの初期化
		//phychicEffect.gameObject.SetActive (false);
		phychicEffect.gameObject.transform.localScale = new Vector3 (0.5f,0.5f,0.5f);
	}
		
	//ゴールを生成
	[Command]
	void CmdSpawnGoal(){
		if (!isServer) {
			return;
		}
		GameObject goalinstance = (GameObject)Instantiate (goalPrefab);
		NetworkServer.SpawnWithClientAuthority (goalinstance,gameObject);
	}

	//GameManagerの生成
	[Command]
	void CmdSpawnGameManager(){
		if(!isServer){
			return;
		}
		GameObject gminstance = (GameObject)Instantiate (gmPrefab);
		NetworkServer.SpawnWithClientAuthority (gminstance,gameObject);
	}

	void Update () {
		//各シーンにおけるプレイヤー１の表示の制御
		if(isplayer1){
			if (OfflineSceneManager.scenename == "MHAMain2") {
				gameObject.SetActive (false);
			} else {
				gameObject.SetActive (true);
			}
		}
		//各シーンにおけるプレイヤー２の表示の制御
		if(isplayer2){
			if (OfflineSceneManager.scenename == "MHAMain") {
				gameObject.SetActive (false);
			} else {
				gameObject.SetActive (true);
			}
		}
		//集中度によってリモコンにエフェクトを発生
//		currentAtt = DisplayData.Attention;
//		if (currentAtt >= 60) {
//			phychicEffect.gameObject.SetActive (false);
//			phychicEffect.gameObject.SetActive (true);
//			phychicEffect.gameObject.transform.localScale = new Vector3 (1f,1f,1f);
//		} else {
//			//phychicEffect.gameObject.SetActive (false);
//			phychicEffect.gameObject.transform.localScale = new Vector3 (0.5f,0.5f,0.5f);
//		}
	}
}
