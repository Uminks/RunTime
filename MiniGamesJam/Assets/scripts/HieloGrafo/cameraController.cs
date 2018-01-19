using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

	public Transform player;
	public float offset = 2f;

	/// 
	/// Moviendo camara
	/// 
	void Update () {
		if (player == null) {
			return;
		}
		transform.position = new Vector3 (player.position.x, player.position.y, transform.position.z);
	}
}
