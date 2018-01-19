using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonCerrarMensaje : MonoBehaviour {

	public void CerrarMensaje(){
		GameObject.Find ("GameOverPanelInflacion").SetActive (false);
	}

	public void CerrarMensajeNoPasar(){
		GameObject.Find ("NoPasar").SetActive (false);
	}
}
