using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CreatePlayer : MonoBehaviour {
	NetworkConnection connectionToClient;

	void Start(){
		//クライアントのシーン上で準備ができたらこれを呼ぶ必要がある
		//ClientScene.Ready (connectionToClient);
		PlayerSpawn ();
	}

	void PlayerSpawn(){
		//PlayerInfoMessageオブジェクトを作成し、プレイヤー情報を格納する
		PlayerInfoMessage msg = new PlayerInfoMessage();
		msg.type = PlayerInfo.type;//←PlayerInfoMessageにPlayerInfoの情報を格納
		//サーバーにAddPlayerMessageを送信
		//その際に、第三引数に追加情報(PlayerInfoMessage)を付与する
		ClientScene.AddPlayer (connectionToClient,0,msg);
	}
	

}
