using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MindValueDisplay : MonoBehaviour {
	private DisplayData DD;
	private string gm;
	private Text mtext;
	// Use this for initialization
	void Start () {
		DD = GameObject.FindGameObjectWithTag ("DD").GetComponent<DisplayData>();
		mtext = GetComponent<Text> ();
		gm = gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
		if(gm == "Attention"){
			mtext.text = "Attention = " + DD.SetAttention ();
		}

		if(gm == "Delta"){
			mtext.text = "Delta = " + DD.SetDelta ();
		}
	}
}
