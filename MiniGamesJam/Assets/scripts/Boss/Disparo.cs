using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour {

	private int direccion;
	private AudioSource s;

	void Start(){
		direccion = Random.Range (0, 3);
		s = GetComponent<AudioSource> ();
		s.Play ();
	}
		

	void Update(){
		
		if(direccion == 0)
			transform.Translate (Vector2.up * 0.1f);
		else if(direccion==1)
			transform.Translate (Vector2.left * 0.1f);
		else
			transform.Translate (Vector2.right * 0.1f);
		
	}

}
