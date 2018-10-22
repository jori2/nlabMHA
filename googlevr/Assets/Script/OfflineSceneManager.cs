using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineSceneManager : MonoBehaviour {
	public static string scenename;
	void Start(){
		scenename = "MHAMain";
	}
	//toggle1のIsONがtrueになるとMHAMainシーンに切り替わる
	public void LoadMHAMain(){
			scenename = "MHAMain";
	}
	//toggle2のIsONがtrueになるとMHAMain2シーンに切り替わる
	public void LoadMHAMain2(){
			scenename = "MHAMain2";
	}
}
