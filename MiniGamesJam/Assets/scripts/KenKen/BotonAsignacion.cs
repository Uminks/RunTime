using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonAsignacion : MonoBehaviour {

	public ControllerMainGame controller;
	public int numberAsignacion;

	void Start(){
		controller = GameObject.Find ("Controller").GetComponent<ControllerMainGame> ();
	}

	public void asignar(){
		for (int i = 0; i < controller.botonesMapaGO.Length; i++) {
			if (controller.botonesMapaGO [i].GetComponent<Button> ().interactable == true) {
				controller.botonesMapaGO [i].GetComponentInChildren<Text> ().text = numberAsignacion.ToString();
				break;
			} 
		}
	}


}
