using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerShoot : NetworkBehaviour {

	public GameObject bulletPrefab;
	private Transform bulletSpawn;
	//脳波計
	private int currentAtt;

	AudioSource sound;

	void Start (){
		bulletSpawn = GameObject.FindWithTag ("ControllerVisual").transform;
		AudioSource[] audioSource = GetComponents<AudioSource> ();
		sound = audioSource [2];
	}

	void Update(){
		if (isLocalPlayer == false) {
			return;
		}

			if(GvrController.ClickButtonDown == true){
				float EP = GetComponent<PlayerController> ().energyPoint;
				if(EP >= 80){
					Fire ();
				}
			}
	}


	void Fire(){
		sound.PlayOneShot (sound.clip);
		var bullet = (GameObject)Instantiate (bulletPrefab,bulletSpawn.position,bulletSpawn.rotation);
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
		Destroy(bullet, 3.0f);
	}
}
