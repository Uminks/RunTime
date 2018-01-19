using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressed : MonoBehaviour {

	public Button[] botones;
	public ControllerMainGame controller;
	private bool deseleccionar = false;
	public bool correcto = false;

	public int numeroCorrecto;

	void Start(){
		seleccionInhabilitada ();
		controller = GameObject.Find ("Controller").GetComponent<ControllerMainGame> ();
	}

	public void asignarNumero(){
		
		seleccionHabilitada ();

		if (deseleccionar) {
			//Volver a hacer Interactable
			for (int i = 0; i < controller.botonesMapaGO.Length; i++) {
				if (controller.botonesMapaGO [i].GetComponent<Button> ().interactable == false) {
					hacerInteractables ();
					seleccionInhabilitada ();
					deseleccionar = false;
					break;
				} 
			}
		} else {
			
			//Poner Interactables los demas
			for (int i = 0; i < controller.botonesMapaGO.Length; i++) {

				if (controller.botonesMapaGO [i].GetComponent<ButtonPressed> () != this) {
					controller.botonesMapaGO [i].GetComponent<Button> ().interactable = false;
					deseleccionar = true;
				}
			}
		}
			
	}


	private void hacerInteractables(){
		for (int i = 0; i < controller.botonesMapaGO.Length; i++) {
			controller.botonesMapaGO [i].GetComponent<Button> ().interactable = true;
		}
	}

	/// <summary>
	/// Seleccion inhabilitada. Para habilitar botones inferiores
	/// </summary>
	private void seleccionHabilitada(){
		for (int i = 0; i < botones.Length; i++) {
			botones [i].interactable = true;
		}
	}

	/// <summary>
	/// Seleccion inhabilitada. Para inhabilitar botones inferiores
	/// </summary>
	private void seleccionInhabilitada(){
		for (int i = 0; i < botones.Length; i++) {
			botones [i].interactable = false;
		}
	}





	void Update(){
		
		if (this.GetComponentInChildren<Text> ().text == numeroCorrecto.ToString ()) {
				
			if(correcto == false){
				this.GetComponent<Image> ().color = Color.green;
				correcto = true;
			}
						
		} else {
			this.GetComponent<Image> ().color = Color.white;
			correcto = false;
		}
	}



}
