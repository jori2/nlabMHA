using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBillboard : MonoBehaviour {
	[SerializeField] GameObject player;
	// Update is called once per frame
	void Update () {
		transform.LookAt (player.transform.position);
	}
}
