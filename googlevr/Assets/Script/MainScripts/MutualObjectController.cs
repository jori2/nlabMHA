using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MutualObjectController : MonoBehaviour {
	public GameObject childcloud;
	public GameObject childenemy;
	public bool isPlayer;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		childcloud = transform.GetChild (0).gameObject;
		childenemy = transform.GetChild (1).gameObject;
		isPlayer = false;
		if(SceneManager.GetActiveScene().name == "MHAMain"){
			childcloud.gameObject.SetActive (true);
			childenemy.gameObject.SetActive (false);
		}else if(SceneManager.GetActiveScene().name == "MHAMain2"){
			childcloud.gameObject.SetActive (false);
			childenemy.gameObject.SetActive (true);
		}
	}

}
