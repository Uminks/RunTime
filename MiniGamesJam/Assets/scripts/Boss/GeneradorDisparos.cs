using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDisparos : MonoBehaviour {

	public GameObject disparo;
	public float Time;

	// Use this for initialization
	void Start () {
		generador ();
	}
	
	void generador(){
		Instantiate(disparo, this.transform.position , Quaternion.identity);
		Invoke("generador", Time);
	}
		
}
