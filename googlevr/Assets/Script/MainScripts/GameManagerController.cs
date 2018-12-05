using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameManagerController : NetworkBehaviour {
	private GameObject goaltext;
	// Use this for initialization
	void Start () {
		//ゴールテキストの検索
		goaltext = GameObject.FindWithTag ("GoalText");
	}

	//CmdDestroyMutualObjを呼ぶ
	public void CallDestroyMethod(GameObject enemy){
//		if(!isLocalPlayer){
//			return;
//		}
		CmdDestroyMutualObj (enemy);
	}

	public void CallP2GameOverMethod(){
//		if(!isLocalPlayer){
//			return;
//		}
		Debug.Log ("CallP2GameOver");
		CmdP2GameOverMessage ();
	}

	//Player1がゲームオーバーかチェック
	[Command]
	void CmdDestroyMutualObj(GameObject Enemy){
//		if(!isServer){
//			return;
//		}
		RpcDestroyMutualObj(Enemy);
	}

	//Player1のゲームオーバーを通知するようにサーバーに通知
	[Command]
	void CmdP1GameOverMessage(){
//		if(!isServer){
//			return;
//		}
		RpcP1GameOverMessage ();
	}

	//サーバーに該当のMutualObjを破壊するように通知
	[Command]
	void CmdDestroyMutualObjMessage(GameObject Enemy){
//		if(!isServer){
//			return;
//		}
		NetworkServer.Destroy (Enemy);
	}

	//Player2がゲームオーバーしたことをサーバーに通知
	[Command]
	void CmdP2GameOverMessage(){
//		if(!isServer){
//			return;
//		}
		Debug.Log ("CmdP2GameOver");
		RpcP2GameOverMessage ();
	}

	//MHAMainに該当の敵が破壊されたことを通知
	//破壊された敵のMutualOnjectのisPlayerがtrueならCmdP1GameOverMessageを実行
	//チェック後に該当のMOJを破壊
	[ClientRpc]
	void RpcDestroyMutualObj(GameObject Enemy){
		if(SceneManager.GetActiveScene().name == "MHAMain"){
			GameObject parent = Enemy.transform.root.gameObject;
			if (parent.GetComponent<MutualObjectController> ().isPlayer == true) {
				CmdP1GameOverMessage ();
			}
			CmdDestroyMutualObjMessage (Enemy);
		}
	}

	//SetPlayerNumberに3（Player1のゲームオーバー）を通知
	[ClientRpc]
	void RpcP1GameOverMessage(){
		goaltext.GetComponent<GoalTextController> ().SetPlayerNumber (3);
	}

	//Player2がゲームオーバーしたことを全クライアントに通知
	[ClientRpc]
	void RpcP2GameOverMessage(){
		Debug.Log ("RpcP2GameOver");
		goaltext.GetComponent<GoalTextController> ().SetPlayerNumber (4);
	}


}
