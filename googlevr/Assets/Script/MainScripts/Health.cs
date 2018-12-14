using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {
	private int damage;
	private int maxhealth;
	bool isGameOver;
	private GameObject gm;
	private AudioSource sound;
	public GameObject mainCamera;
//	[SerializeField] GameObject[] blood;

	// Use this for initialization
	void Start () {
		AudioSource[] audioSource = GetComponents<AudioSource> ();
		sound = audioSource [2];
		maxhealth = 10;
		damage = 0;
		isGameOver = false;
		mainCamera = transform.GetChild (1).gameObject;
	}

	//敵の玉が当たったらdamageを１増やす
	//血飛沫の描画処理
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.CompareTag("EnemyBullet")){
			sound.PlayOneShot (sound.clip);
			mainCamera.GetComponent<ShakeCamera> ().CatchShake ();
			damage++;
//			for(int i = 0;i<maxhealth-1;i++){
//				if(i<=damage){
//					blood [i].gameObject.GetComponent<Image> ().enabled = true;
//				}else if(i>damage){
//					blood [i].gameObject.GetComponent<Image> ().enabled = false;
//				}
//			}
			if(damage>=maxhealth){
				if(isGameOver == false){
					gm = GameObject.FindWithTag ("GM2");
					gm.gameObject.GetComponent<GameManagerController> ().CallP2GameOverMethod ();
					isGameOver = true;
				}
			}
		}
	}
}
