using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {
	public int damage;
	private int maxhealth;
	bool isGameOver;
	private GameObject gm;
	private AudioSource sound;
	private AudioSource sound2;
	//public GameObject mainCamera;
//	[SerializeField] GameObject[] blood;

	// Use this for initialization
	void Start () {
		AudioSource[] audioSource = GetComponents<AudioSource> ();
		sound = audioSource [3];
		maxhealth = 10;
		damage = 0;
		isGameOver = false;
		//mainCamera = transform.GetChild (1).gameObject;
	}

	//敵の玉が当たったらdamageを１増やす
	//血飛沫の描画処理
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.CompareTag("EnemyBullet")){
			sound.PlayOneShot (sound.clip);
			//mainCamera.GetComponent<ShakeCamera> ().CatchShake ();
			//ダメージを受けるとシェイク
			gameObject.GetComponent<ShakeCamera> ().CatchShake ();
			damage++;
//			for(int i = 0;i<maxhealth-1;i++){
//				if(i<=damage){
//					blood [i].gameObject.GetComponent<Image> ().enabled = true;
//				}else if(i>damage){
//					blood [i].gameObject.GetComponent<Image> ().enabled = false;
//				}
//			}
			//ゲームオーバーの処理
			if(damage>=maxhealth){
				//ゲームオーバーテキスト
//				if(isGameOver == false){
//					gm = GameObject.FindWithTag ("GM2");
//					gm.gameObject.GetComponent<GameManagerController> ().CallP2GameOverMethod ();
//					isGameOver = true;
//				}
				//現在の親子関係を解除する
				transform.parent = null;
				gameObject.GetComponent<PlayerController> ().GameOver ();
				//gameObject.transform.position = new Vector3 (0,2,0);
				damage = 0;
			}
		}
	}

//	void Update(){
//		if(GvrController.ClickButtonDown == true){
//			transform.parent = null;
//			gameObject.transform.position = new Vector3 (0,2,0);
//		}
//	}
}
