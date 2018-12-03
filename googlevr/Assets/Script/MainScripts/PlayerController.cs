using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {
	[SerializeField] bool isplayer1;
	[SerializeField] bool isplayer2;
	[SerializeField] GameObject goalPrefab;
	[SerializeField] GameObject phychicEffect;
	private GameObject goaltext;
	private int currentAtt;

	//CmdDestroyMutualObjを呼ぶ
	public void CallDestroyMethod(GameObject enemy){
		if(!isLocalPlayer){
			return;
		}
		CmdDestroyMutualObj (enemy);
	}

	//(MHAMain2)敵をサーバーとすべてのクライアントから削除
	[Command]
	void CmdDestroyMutualObj(GameObject Enemy){
		//NetworkServer.Destroy (Enemy);
		RpcDestroyMutualObj(Enemy);
	}

	//Player1のゲームオーバーを通知するようにサーバーに通知
	[Command]
	void CmdP1GameOverMessage(){
		RpcP1GameOverMessage ();
	}

	//MHAMainに該当の敵が破壊されたことを通知
	//破壊された敵のMutualOnjectのisPlayerがtrueならCmdP1GameOverMessageを実行
	[ClientRpc]
	void RpcDestroyMutualObj(GameObject Enemy){
		if(SceneManager.GetActiveScene().name == "MHAMain"){
			GameObject parent = Enemy.transform.root.gameObject;
			if (parent.GetComponent<MutualObjectController> ().isPlayer == true) {
				CmdP1GameOverMessage ();
			}
		}
	}

	//SetPlayerNumberに3（Player1のゲームオーバー）を通知
	[ClientRpc]
	void RpcP1GameOverMessage(){
		goaltext.GetComponent<GoalTextController> ().SetPlayerNumber (3);
	}


		
	void Start(){
		if (!isLocalPlayer) {
			return;
		}
		//effectの初期化
		//phychicEffect.gameObject.SetActive (false);
		phychicEffect.gameObject.transform.localScale = new Vector3 (0.5f,0.5f,0.5f);
		if(SceneManager.GetActiveScene().name == "MHAMain"){
			CmdSpawnGoal ();
		}
		//ゴールテキストの検索
		goaltext = GameObject.FindWithTag ("GoalText");
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
		currentAtt = DisplayData.Attention;
		if (currentAtt >= 60) {
			phychicEffect.gameObject.SetActive (false);
			phychicEffect.gameObject.SetActive (true);
			phychicEffect.gameObject.transform.localScale = new Vector3 (1f,1f,1f);
		} else {
			//phychicEffect.gameObject.SetActive (false);
			phychicEffect.gameObject.transform.localScale = new Vector3 (0.5f,0.5f,0.5f);
		}
	}
}
