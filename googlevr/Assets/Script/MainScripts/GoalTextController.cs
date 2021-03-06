﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalTextController : MonoBehaviour {
	bool isgoaltext;
	GameObject parent;
	Vector3 ppos;
	void Start(){
		isgoaltext = false;
		parent = transform.root.gameObject;
	}
	//プレイヤーをゴール時の位置に固定
	void Update(){
		if(isgoaltext == true){
			parent.transform.position = ppos;
		}
	}
	//ゴールしたプレイヤーを表示
	//プレイヤーの位置を固定する
	public void SetPlayerNumber(int getplayernumber){
		isgoaltext = true;
		GetPlayerPosition ();
		if(getplayernumber == 1){
			gameObject.GetComponent<Text>().text = "Player1 Goal";
		}else if(getplayernumber == 2){
			gameObject.GetComponent<Text>().text = "Player2 Goal";
		}else if(getplayernumber == 3){
			gameObject.GetComponent<Text>().text = "Player1 GameOver";
		}else if(getplayernumber == 4){
			gameObject.GetComponent<Text>().text = "Player2 GameOver";
		}
	}

	void GetPlayerPosition(){
		ppos = parent.transform.position;
	}
}
