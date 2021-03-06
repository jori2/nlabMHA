﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {
	public GameObject redbulletPrefab;
	public Transform enemybulletSpawn;
	private float time;
	private Animation_Test anim;
	private bool idle;
	private bool attack;
	private bool death;
	//親オブジェクト
	private GameObject parent;

	private GameObject player;
	private GameObject gm;

	private AudioSource sound;


	private int scalecount;
	// Use this for initialization
	void Start () {
		parent = transform.root.gameObject;
		if(SceneManager.GetActiveScene().name == "MHAMain" || SceneManager.GetActiveScene().name == "MHAMain2"){
			player = GameObject.FindWithTag ("Player2");
		}

		scalecount = 1;

		AudioSource audioSource = GetComponent<AudioSource> ();
		sound = audioSource;

		anim = GetComponent<Animation_Test> ();
		idle = true;
		attack = false;
		death = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().name == "MHAMain" || SceneManager.GetActiveScene().name == "MHAMain2"){
			transform.LookAt (player.gameObject.transform.position);
		}
		time += Time.deltaTime;
		if(time > 3){
			idle = false;
			attack = true;
			EnemyFire ();
			time = 0;
		}
		if(idle){
			anim.IdleAni ();
		}else if(death){
			anim.DeathAni ();
		}else if(attack){
			anim.AttackAni ();
		}

		if(scalecount<=30){
			gameObject.transform.localScale = new Vector3(0.06f * scalecount,0.06f * scalecount,0.06f * scalecount);
			scalecount++;
		}
	}

	void EnemyFire(){
		var bullet = (GameObject)Instantiate (redbulletPrefab,enemybulletSpawn.position,enemybulletSpawn.rotation);
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
		Destroy(bullet, 2.0f);
		Invoke ("InitiallizeAni",0.5f);
	}

	void InitiallizeAni(){
		idle = true;
		attack = false;
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "Bullet"){
			idle = false;
			death = true;
			sound.PlayOneShot (sound.clip);
			Invoke ("DestroyEnemy",0.7f);
		}
	}
		
	void DestroyEnemy(){
		idle = true;
		death = false;
		gm = GameObject.FindWithTag ("GM2");
		gm.gameObject.GetComponent<GameManagerController> ().CallDestroyMethod (parent);
	}
}
