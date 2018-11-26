using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public static class PlayerType{
	public const int Player1 = 0;
	public const int Player2 = 1;
}

class PlayerInfoMessage : MessageBase{
	public int type;
}

public class PlayerInfo : MonoBehaviour {
	//アクティブなシーン名に応じてPlayerInfo.typeにPlayerTypeを格納する
	public static int type = PlayerType.Player1;

	// Update is called once per frame
	public void OnMHAMain1ValueChanged () {
		type = PlayerType.Player1;
	}

	public void OnMHAMain2ValueChanged () {
		type = PlayerType.Player2;
	}
		
}
