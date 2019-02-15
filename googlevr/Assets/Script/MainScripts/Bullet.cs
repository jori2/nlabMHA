using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[SerializeField] bool isbullet;
	void OnCollisionEnter(Collision collision){
		if(isbullet == true){
			if(collision.gameObject.tag != "EnemyBullet"){
				Destroy (gameObject);
			}
		}else if (isbullet == false){
			Destroy (gameObject);
		}
	}
}
