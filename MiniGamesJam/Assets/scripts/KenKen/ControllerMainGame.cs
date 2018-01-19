using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMainGame : MonoBehaviour {

	public GameObject[] botonesMapaGO;
	public GameObject emergenteGanar;
	private int cont = 0;

	void Start () {
		emergenteGanar.SetActive (false);
		botonesMapaGO = GameObject.FindGameObjectsWithTag ("casillasKen");

	}
	
	void Update () {

		if (cont != botonesMapaGO.Length) {	
			
			for (int i = 0; i < botonesMapaGO.Length; i++) {
				if (botonesMapaGO [i].GetComponent<ButtonPressed> ().correcto == true) {
					cont++;
				} else {
					cont = 0;
					break;
				}
			}

			if (cont == botonesMapaGO.Length) {
				emergenteGanar.SetActive (true);
			}
			
		}




	}
}
