using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limites : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D obj){

		if (obj.transform.tag == "Pared") {
			Destroy (obj.transform.gameObject);
		}
		
	}
}
