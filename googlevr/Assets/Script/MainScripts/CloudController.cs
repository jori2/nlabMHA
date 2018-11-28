using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {
	private int scalecount;
	//GameObject player;
	GameObject canvas;
	[SerializeField] GameObject DWindow;
	[SerializeField] GameObject FireMonster;
	void Start(){
		canvas = GameObject.FindWithTag ("canvas");
		//異次元窓を生成
		GameObject prefab = (GameObject)Instantiate (DWindow,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y+1,gameObject.transform.position.z),gameObject.transform.rotation);
		prefab.transform.SetParent (canvas.transform,true);
		//モンスター出現&縮小
		Instantiate(FireMonster,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y+1,gameObject.transform.position.z),gameObject.transform.rotation);
		scalecount = 0;
		//player = GameObject.FindWithTag("Player");
	}

	void Update () {
//		//BillBoard
//		if (player != null) {
//			transform.LookAt (player.transform.position);
//		}
		if(scalecount<=10){
			gameObject.transform.localScale = new Vector3(0.01f * scalecount,0.01f * scalecount,0.01f * scalecount);
			scalecount++;
		}
	}
}
