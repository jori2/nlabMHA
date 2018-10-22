using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {
	

	public void CallDestroyMethod(GameObject enemy){
		if(!isLocalPlayer){
			return;
		}
		CmdDestroyMutualObj (enemy);
	}
//
//	public void CallSpawnMethod(GameObject cloud){
//		if(!isLocalPlayer){
//			return;
//		}
//		CmdSpawnMutualObj (cloud);
//	}
//
	[Command]
	public void CmdDestroyMutualObj(GameObject Enemy){
		NetworkServer.Destroy (Enemy);
	}
		
//
//	[Command]
//	public void CmdSpawnMutualObj(GameObject Cloud){
//		NetworkServer.Spawn (Cloud);
//		//雲が生成されました
//	}

}
