using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {
	[SerializeField] bool isplayer1;
	[SerializeField] bool isplayer2;
	[SerializeField] GameObject goalPrefab;

	//CmdDestroyMutualObjを呼ぶ
	public void CallDestroyMethod(GameObject enemy){
		if(!isLocalPlayer){
			return;
		}
		CmdDestroyMutualObj (enemy);
	}

	//敵をサーバーとすべてのクライアントから削除
	[Command]
	public void CmdDestroyMutualObj(GameObject Enemy){
		NetworkServer.Destroy (Enemy);
	}
		
	void Start(){
		if (!isLocalPlayer) {
			return;
		}
		CmdSpawnGoal ();
	}

	[Command]
	void CmdSpawnGoal(){
		if (!isServer) {
			return;
		}
		GameObject goalinstance = (GameObject)Instantiate (goalPrefab);
		NetworkServer.SpawnWithClientAuthority (goalinstance,gameObject);
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
	}
}
