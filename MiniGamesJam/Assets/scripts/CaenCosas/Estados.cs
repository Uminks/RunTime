using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Estados : MonoBehaviour {

	public int piezas = 0;
	private int precio;
	public GameObject panelGanar;
	private bool recolectoYA=false;
	public GameObject EstadoPRECIO;
	//private float min = 1, seg = 59;

	public Text text_piezas;
	public Text text_precio;
	//public Text text_tiempo;

	void Start(){
		panelGanar.SetActive (false);
		EstadoPRECIO = GameObject.Find ("EstadoPrecio");
		precio = EstadoPRECIO.GetComponent<EstadoPrecio> ().PRECIO;

	}

	public void puntos () {
		piezas += 1;
	}

	public void restPunto(){
		if (piezas > 0) {
			piezas -= 1;
		}
	}

	public void inflacion(){
		precio += 1; 
	}

	public void Update () {
	
		//seg -= Time.deltaTime;
		if (!recolectoYA) {

			EstadoPRECIO.GetComponent<EstadoPrecio> ().PRECIO = precio;
			text_piezas.text = "Piezas : " + piezas + "/8";
			text_precio.text = "Precio : " + EstadoPRECIO.GetComponent<EstadoPrecio> ().PRECIO +"Bsf";

			if (piezas == 8) {
				panelGanar.SetActive (true);
				recolectoYA = true;
			}
		}
		/*if (seg <= 0) {
			min -= 1;
			seg = 59;
		}
		text_tiempo.text = "Tiempo : " + min + " : " + seg.ToString("0");*/
	}
}
