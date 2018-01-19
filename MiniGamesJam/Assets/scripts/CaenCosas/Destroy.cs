using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public Estados score;

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag == "bad") {
			score.inflacion ();
			Destroy (col.gameObject);
		}
		if (col.transform.tag == "good") {
			Destroy(col.gameObject);
		}
	}
}
