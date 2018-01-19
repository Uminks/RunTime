using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComparacionFinal : MonoBehaviour {

	public GameObject EstadoPRECIO;
	public Text txtPrecio;

	void Start () {

		EstadoPRECIO = GameObject.Find ("EstadoPrecio");
		txtPrecio.text = EstadoPRECIO.GetComponent<EstadoPrecio> ().PRECIO+" / 500";

		if (EstadoPRECIO.GetComponent<EstadoPrecio> ().PRECIO <= 500) {
			txtPrecio.text = txtPrecio.text + "\n\r" + "Lo lograste,que disfrutes el concierto";
		} else {
			txtPrecio.text = txtPrecio.text + "\n\r" + "No lo lograste, vuelve a intentarlo";
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
