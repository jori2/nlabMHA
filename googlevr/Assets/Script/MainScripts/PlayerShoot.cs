using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerShoot : NetworkBehaviour {

	public GameObject bulletPrefab;
	private Transform bulletSpawn;
	//脳波計
//	private int currentAtt;

	void Start (){
		bulletSpawn = GameObject.FindWithTag ("ControllerVisual").transform;
	}

	void Update(){
		//脳波計
//		currentAtt = DisplayData.Attention;
		if (isLocalPlayer == false || OfflineSceneManager.scenename != "MHAMain2") {
			return;
		}
		//脳波計
//		if(currentAtt >= 60){
			if(GvrController.ClickButtonDown == true){
				Fire ();
			}
//		}
	}


	void Fire(){
		var bullet = (GameObject)Instantiate (bulletPrefab,bulletSpawn.position,bulletSpawn.rotation);
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
		Destroy(bullet, 2.0f);
	}
}
