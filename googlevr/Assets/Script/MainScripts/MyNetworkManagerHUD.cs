﻿using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyNetworkManagerHUD : MonoBehaviour
{
	// ボタン等の主なUIを含むGameObject
	GameObject m_MainUIs;

	// 接続中であることを示すUIのGameObject
	GameObject m_ConnectingText;
	private bool istext;

	// 接続状態種別
	enum ConnectionState
	{
		// 純粋なサーバーとして起動中
		Server,
		// ホスト（サーバー兼クライアント）として起動中
		Host,
		// リモートクライアントとして接続確立済み
		RemoteClientConnected,
		// リモートクライアントとして接続試行中
		RemoteClientConnecting,
		// 接続なし
		Nothing,
	}

	// ネットワーク接続の状態を取得する
	ConnectionState GetConnectionState()
	{
		// サーバーが起動しているか？
		if (NetworkServer.active)
		{
			// クライアントとして接続しているか？
			if (NetworkManager.singleton.IsClientConnected())
			{
				// ホストとして起動中
				return ConnectionState.Host;
			}
			else
			{
				// サーバーとして起動中
				return ConnectionState.Server;
			}
		}
		// クライアントとして接続しているか？
		else if (NetworkManager.singleton.IsClientConnected())
		{
			// リモートクライアントとして接続確立済み
			return ConnectionState.RemoteClientConnected;

		}
		else
		{
			NetworkClient client = NetworkManager.singleton.client;

			// Connectionが存在するか？
			if (client != null && client.connection != null && client.connection.connectionId != -1)
			{
				// 接続試行中
				return ConnectionState.RemoteClientConnecting;


			}
			else
			{
				// 接続なし（何もしていない）
				return ConnectionState.Nothing;
			}
		}
	}

	void Start()
	{
		m_MainUIs = GameObject.Find("MainUIs");
//		m_MainUIs.SetActive (false);
		m_ConnectingText = GameObject.Find("ConnectingText");
		istext = false;
	}

	void Update()
	{
		ConnectionState state = GetConnectionState();

			m_ConnectingText.GetComponent<Text>().text = OfflineSceneManager.scenename + "Selected";
		
		// 接続試行中
		if (state == ConnectionState.RemoteClientConnecting)
		{
			m_MainUIs.SetActive(false);
			m_ConnectingText.SetActive(true);

			// Escapeキーで接続中止
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				NetworkManager.singleton.StopHost();
			}
		}
		else if(state == ConnectionState.RemoteClientConnected){
			m_MainUIs.SetActive(false);
			m_ConnectingText.SetActive(false);
			SceneManager.LoadScene (OfflineSceneManager.scenename);
		}
		else{
			m_MainUIs.SetActive(true);
			m_ConnectingText.SetActive(false);
		}
		//スペースキーでサーバーとして起動
		if(Input.GetKeyDown(KeyCode.Space)){
			OnServerButtonClicked ();
		}
		if (istext == false) {
			if (NetworkServer.active) {
				Debug.Log ("Server activate");
				m_ConnectingText.GetComponent<Text> ().text = "Server Activate";
				istext = true;
			}
		}
	}

	// 「サーバーとして起動」ボタンが押された時の処理
	public void OnServerButtonClicked()
	{
		NetworkManager.singleton.StartServer();
	}

	// 「ホストとして起動」ボタンが押された時の処理
	public void OnHostButtonClicked()
	{
		NetworkManager.singleton.StartHost();
	}

	// 「サーバーへ接続(クライアント)」ボタンが押された時の処理
	public void OnClientButtonClicked()
	{
		
		NetworkManager.singleton.StartClient ();
		
	}
}