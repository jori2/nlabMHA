using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameManagerController : NetworkBehaviour {
	[SerializeField] GameObject goaltext;
	private GameObject gm1;
	public GameObject selectObject;
	public int createcount;

	void Start(){
		createcount = 0;
	}

	//CmdDestroyMutualObjを呼ぶ
	public void CallDestroyMethod(GameObject enemy){
//		if(!isLocalPlayer){
//			return;
//		}
		CmdDestroyMutualObj (enemy);
	}

	//CmdP1GameOverMessageを呼ぶ
	public void CallP1GameOverMessage(){
//		CmdP1GameOverMessage ();


		//プレイヤーを元の位置に戻す
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GameOver();
	}

	//CmdDestroyMutualObjMessageを実行
	public void CallDestroyMutualObjMessage(GameObject Enemy){
		CmdDestroyMutualObjMessage (Enemy);
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
		Debug.Log("CmdP1GameOver");
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
		if(!isServer){
			return;
		}
		Debug.Log ("CmdP2GameOver");
		RpcP2GameOverMessage ();
	}

	//RpcDestroyMutualObjはgm2が実行し、その後の処理はgmが実行
	//MHAMainに該当の敵が破壊されたことを通知
	//破壊された敵のMutualOnjectのisPlayerがtrueならCmdP1GameOverMessageを実行
	//チェック後に該当のMOJを破壊
	[ClientRpc]
	void RpcDestroyMutualObj(GameObject Enemy){
		if(SceneManager.GetActiveScene().name == "MHAMain"){
			gm1 = GameObject.FindGameObjectWithTag ("GM");
			GameObject parent = Enemy.transform.root.gameObject;
			if (parent.GetComponent<MutualObjectController> ().isPlayer == true) {
				gm1.gameObject.GetComponent<GameManagerController> ().CallP1GameOverMessage ();
			}
			gm1.gameObject.GetComponent<GameManagerController>().CallDestroyMutualObjMessage (Enemy);
		}
	}

	//SetPlayerNumberに3（Player1のゲームオーバー）を通知
	[ClientRpc]
	void RpcP1GameOverMessage(){
		Debug.Log ("RpcP1GameOver");
		//ゴールテキストの検索
		if(SceneManager.GetActiveScene().name == "MHAMain"){
			goaltext = GameObject.FindWithTag ("GoalText");
		}else if(SceneManager.GetActiveScene().name == "MHAMain2"){
			goaltext = GameObject.FindWithTag ("GoalText2");
		}
		goaltext.GetComponent<GoalTextController> ().SetPlayerNumber (3);
	}

	//Player2がゲームオーバーしたことを全クライアントに通知
	[ClientRpc]
	void RpcP2GameOverMessage(){
		Debug.Log ("RpcP2GameOver");
		//ゴールテキストの検索
		if(SceneManager.GetActiveScene().name == "MHAMain"){
			goaltext = GameObject.FindWithTag ("GoalText");
		}else if(SceneManager.GetActiveScene().name == "MHAMain2"){
			goaltext = GameObject.FindWithTag ("GoalText2");
		}
		goaltext.GetComponent<GoalTextController> ().SetPlayerNumber (4);
	}

	//現在選択されているMOJは何か
	public void GetSelectObject(GameObject SObject){
		selectObject = SObject;
	}

	public void Setcreatecount(){
		createcount++;
	}
}
