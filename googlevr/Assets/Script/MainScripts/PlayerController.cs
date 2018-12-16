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
	public float energyPoint;
	public bool isCharge;
	private int effValue;
	private AudioSource sound1;
	private AudioSource sound2;
	ParticleSystem.MainModule par;
		
	void Start(){
		if (!isLocalPlayer) {
			return;
		}
		CmdSpawnGoal ();
		CmdSpawnGameManager ();
		AudioSource[] audioSource = GetComponents<AudioSource> ();
		sound1 = audioSource [0];
		sound2 = audioSource [1];
		energyPoint = 0;
		effValue = 0;
		//effectの初期化
		//phychicEffect.gameObject.SetActive (false);
		par = phychicEffect.GetComponent<ParticleSystem> ().main;
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

		//集中度による制御
		currentAtt = DisplayData.Attention;
		if (energyPoint >= 60 && currentAtt >= 60) {

			//SEの制御

			if (sound2.isPlaying == false) {
				sound2.Play ();
			}

			if (sound1.isPlaying == true) {
				sound1.Stop ();
			}

			//EPの制御
			energyPoint += 1f;

			if(energyPoint >= 100){
				energyPoint = 100;
			}

			//ストック
			isCharge = true;

			//particleの制御
			if(effValue == 0 || effValue == 1){
				phychicEffect.gameObject.SetActive (false);
				par.startColor = Color.red;
				phychicEffect.gameObject.SetActive (true);
				phychicEffect.gameObject.transform.localScale = new Vector3 (2f,2f,2f);
				effValue = 2;
			}

		} else if(energyPoint < 60 && currentAtt >= 60) {

			if (sound2.isPlaying == true) {
				sound2.Stop ();
			}

			if (sound1.isPlaying == false) {
				sound1.Play ();
			}

			energyPoint += 1f;

//			if(energyPoint < 0){
//				energyPoint = 0;
//			}else if(energyPoint >= 0){
//				energyPoint -= 0.05f;
//			}
			//phychicEffect.gameObject.SetActive (false);
			if(effValue == 0 || effValue == 2){
				par.startColor = Color.yellow;
				phychicEffect.gameObject.transform.localScale = new Vector3 (1f,1f,1f);
				effValue = 1;
			}
		}else if(currentAtt < 60){
			

			if (sound2.isPlaying == true) {
				sound2.Stop ();
			}

			if (sound1.isPlaying == true) {
				sound1.Stop ();
			}

			energyPoint -= 0.05f;

			if(effValue == 1 || effValue == 2){
				par.startColor = Color.blue;
				phychicEffect.gameObject.transform.localScale = new Vector3 (0.5f,0.5f,0.5f);
				effValue = 0;
			}
		}
	}

	public bool SetCharge(){
		return isCharge;
	}

	public void GetCharge(bool gcharge){
		isCharge = gcharge;
	}
}
