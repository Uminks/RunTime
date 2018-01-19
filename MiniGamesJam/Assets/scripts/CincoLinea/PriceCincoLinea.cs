using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceCincoLinea : MonoBehaviour {

	public Text txtPrecio;
	private float precio;
	public bool stop;
	public GameObject EstadoPRECIO;

	void Start () {
		EstadoPRECIO = GameObject.Find ("EstadoPrecio");
		precio = EstadoPRECIO.GetComponent<EstadoPrecio> ().PRECIO;
		txtPrecio.text = (int)precio + " Bsf";

	}

	void Update () {
		if (!stop) {
			precio += (Time.deltaTime);
			EstadoPRECIO.GetComponent<EstadoPrecio> ().PRECIO = (int)precio; 
			txtPrecio.text = EstadoPRECIO.GetComponent<EstadoPrecio> ().PRECIO + " Bsf";
		}

	}
}
