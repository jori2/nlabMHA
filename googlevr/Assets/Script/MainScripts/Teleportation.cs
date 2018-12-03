using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour {
	private GameObject player;
	private bool IsTransport;
	private float distanceX;
	private float distanceZ;
	private int count = 0;
	public void TeleportatTo(){
		if(SceneManager.GetActiveScene().name == "MHAMain"){
			player = GameObject.FindWithTag ("Player");
			//MutualObjectのisPlayerを初期化
			//選択したMutualObjectのisPlayerをtrue
			GameObject[] MOJs = GameObject.FindGameObjectsWithTag ("MOJ");
			for(int i = 0;i <= MOJs.Length; i++){
				MOJs [i].GetComponent<MutualObjectController> ().isPlayer = false;
			}
			transform.root.gameObject.GetComponent<MutualObjectController> ().isPlayer = true;
		}else if(SceneManager.GetActiveScene().name == "MHAMain2"){
			player = GameObject.FindWithTag ("Player2");
		}
		distanceX = transform.position.x - player.gameObject.transform.position.x;
		distanceZ = transform.position.z - player.gameObject.transform.position.z;
		IsTransport = true;
	}

	void Update(){
		if(IsTransport){
			player.transform.position += new Vector3 (distanceX/5f,0,distanceZ/5f);
			count++;
			if(count == 5){
				IsTransport = false;
				count = 0;
			}
		}
	}
}
