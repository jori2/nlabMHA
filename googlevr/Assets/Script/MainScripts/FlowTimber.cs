using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowTimber : MonoBehaviour {
	private Vector3 timberpos;
	[SerializeField] bool isFlow;
	public  bool isSelect;

	// Use this for initialization
	void Start () {
		isSelect = false;
		if(isFlow){
			timberpos = transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(isFlow){
			TimberTranslate ();
		}
	}

	public void OnClickedIntoChild(){
		GameObject player = GameObject.FindWithTag ("Player2");
		player.transform.parent = this.gameObject.transform;
	}

	void TimberTranslate(){
		transform.Translate (0,0,-0.1f);
		if(transform.position.z <= -47 && isSelect == false){
			transform.position = new Vector3 (timberpos.x,timberpos.y,timberpos.z);
		}else if(transform.position.z <= -47 && isSelect == true){
			transform.position = new Vector3 (timberpos.x,timberpos.y,-47);
		}
	}

	//外部のスクリプトからisSelectを変更する
	public void SetIsSelect(bool setisSelect){
		isSelect = setisSelect;
	}
}
