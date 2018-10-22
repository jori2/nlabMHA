using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerShoot : NetworkBehaviour {

	public GameObject bulletPrefab;
	private Transform bulletSpawn;

	void Start (){
		bulletSpawn = GameObject.FindWithTag ("ControllerVisual").transform;
	}

	void Update(){
		if (isLocalPlayer == false || OfflineSceneManager.scenename != "MHAMain2") {
			return;
		}
		if(GvrController.ClickButtonDown == true){
			Fire ();
		}
	}


	void Fire(){
		var bullet = (GameObject)Instantiate (bulletPrefab,bulletSpawn.position,bulletSpawn.rotation);
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
		Destroy(bullet, 2.0f);
	}
}
