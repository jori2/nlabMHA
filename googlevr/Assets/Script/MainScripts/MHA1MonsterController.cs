using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MHA1MonsterController : MonoBehaviour {
	float time;
	float ENscale;
	//モンスター出現時回転初期化
	void Start(){
		time = 0;
		ENscale = 2;
	}
	//モンスター回転し、消滅
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		// Y軸周りを回転するQuaternionを作成
		Quaternion rotY = Quaternion.AngleAxis(90.0f * Time.deltaTime, Vector3.up);

		// 現在の回転値と合成
		Quaternion newRotation = rotY * transform.rotation;

		// 新しい回転値を設定
		transform.rotation = newRotation;
		//gameObject.transform.Translate (Vector3.up*Time.deltaTime);
		gameObject.transform.localScale= new Vector3 (ENscale/(1+time*time*time*time),ENscale/(1+time*time*time*time),ENscale/(1+time*time*time*time));
		if(time>=2f){
			Destroy (gameObject);
		}
	}
}
