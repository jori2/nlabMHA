using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class SpawnPlane: NetworkBehaviour {
	public GameObject plane;
	// Use this for initialization
	void Start () {
		if(!isLocalPlayer){
			return;
		}
		CmdInstancePlane ();
	}

	[Command]
	void CmdInstancePlane(){
		if(!isServer){
			return;
		}
		GameObject planeinstance = (GameObject)Instantiate (plane,Vector3.zero,Quaternion.identity);
		NetworkServer.SpawnWithClientAuthority (planeinstance,gameObject);
	}
}
