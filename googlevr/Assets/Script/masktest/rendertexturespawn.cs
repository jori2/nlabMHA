using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rendertexturespawn : MonoBehaviour {
	[SerializeField] GameObject canvas;
	[SerializeField] GameObject maskimage;
	// Use this for initialization
	void Start () {
		GameObject prefab = (GameObject)Instantiate(maskimage);
		prefab.transform.SetParent (canvas.transform,false);
	}


}
