using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DWPoint : MonoBehaviour {
	//異次元の窓
	GameObject canvas;
	[SerializeField] GameObject DWindow;
	GameManagerController gm;
	// Use this for initialization
	void Start () {
		//異次元窓を生成
		if(SceneManager.GetActiveScene().name == "MHAMain"){
			gm = GameObject.FindWithTag("GM").GetComponent<GameManagerController>();
			if(gm.createcount >= 5){
				canvas = GameObject.FindWithTag ("canvas");
				GameObject prefab = (GameObject)Instantiate (DWindow,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z),gameObject.transform.rotation);
				prefab.transform.SetParent (canvas.transform,true);
			}
		}else if(SceneManager.GetActiveScene().name == "MHAMain2"){
			canvas = GameObject.FindWithTag ("canvas");
			GameObject prefab = (GameObject)Instantiate (DWindow,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z),gameObject.transform.rotation);
			prefab.transform.SetParent (canvas.transform,true);
		}
	}

}
