using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerShoot : NetworkBehaviour {

	public GameObject bulletPrefab;
	private Transform bulletSpawn;
	AudioSource sound;
	PlayerController pc;

	void Start (){
		bulletSpawn = GameObject.FindWithTag ("ControllerVisual").transform;
		AudioSource[] audioSource = GetComponents<AudioSource> ();
		sound = audioSource [3];
		pc = GetComponent<PlayerController> ();
	}

	void Update(){
		if (isLocalPlayer == false) {
			return;
		}
		if(GvrController.ClickButtonDown == true){
			bool isCharge = pc.SetCharge ();
			if(isCharge == true){
				Fire ();
				pc.GetCharge (false);
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
