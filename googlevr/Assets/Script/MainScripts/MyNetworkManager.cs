using UnityEngine;
using UnityEngine.Networking;
public class MyNetworkManager : NetworkManager {

	[SerializeField] GameObject m_Player1Prefab;
	[SerializeField] GameObject m_Player2Prefab;

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader){
		//PlayerInfoMessageオブジェクトを作成し、AddPlayerMessage(ClientScene.AddPlayer)のmsgを読み取る
		PlayerInfoMessage msg = extraMessageReader.ReadMessage<PlayerInfoMessage> ();
		int playerType = msg.type;

		GameObject playerPrefab;

		//playerTypeの内容によってplayerPrefabに格納するプレハブを変更
		if (playerType == PlayerType.Player1) {
			playerPrefab = m_Player1Prefab;
		} else {
			playerPrefab = m_Player2Prefab;
		}

		GameObject player;
		//NetworkStartPositionコンポーネントを持つオブジェクトがシーンにあれば、そのオブジェクトにプレイヤーを生成する
		Transform startPos = GetStartPosition ();
		if (startPos != null) {
			player = (GameObject)Instantiate (playerPrefab, startPos.position, startPos.rotation);
		} else {
			player = (GameObject)Instantiate (playerPrefab, new Vector3(0,2,0), Quaternion.identity);
		}
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}
}
