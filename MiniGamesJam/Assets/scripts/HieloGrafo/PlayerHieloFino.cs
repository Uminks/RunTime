using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHieloFino : MonoBehaviour {

	public Text recolectado;

	public Sprite[] flechas;
	public SpriteRenderer flecha;

	public GameObject monedas2;
	private int monedas;

	public GameObject PanelWin;
	public GameObject PanelInflacion;
	public GameObject PanelNoPasar;

	private Animator animator;
	private AudioSource audio;

	private bool terminar;
	private PriceHieloGrafo price;

	void Start () {
		monedas = 0;
		recolectado.text = "Recolected: "+monedas+" Bsf";

		flecha = GameObject.Find ("arrow").GetComponent<SpriteRenderer> ();
		flecha.sprite = flechas [1];

		monedas2.SetActive (false);

		PanelInflacion.SetActive (false);
		PanelWin.SetActive (false);
		PanelNoPasar.SetActive (false);

		animator = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();

		terminar = false;
		price = GameObject.FindObjectOfType<PriceHieloGrafo> ();
	}

	void OnCollisionEnter2D(Collision2D obj){
		//0 Amarilla 1 Roja

		//Recoge monedas
		if (obj.transform.tag == "MonedaHieloFino") {
			audio.Play ();
			Destroy (obj.transform.gameObject);
			monedas++;
			recolectado.text = "Recolected: "+monedas+" Bsf";

			if (monedas == 6 || monedas == 15) {
				flecha.sprite = flechas [0];
			}
		}

		if (obj.transform.name == "FlechaPasar") {
			//Primeras monedas
			if(monedas == 6){

				PanelInflacion.SetActive (true);

				flecha.sprite = flechas [1];
				monedas2.SetActive (true);
			}	

			//Termina Juego
			if (monedas == 15) {
				PanelWin.SetActive (true);
				terminar = true;
				price.stop=true;
			}

			//En otros casos
			if(monedas != 6 && monedas != 15){
				PanelNoPasar.SetActive (true);
			}
		}


	}

	void FixedUpdate () {

		//Si no ha terminado
		if (!terminar) {

			if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
				animator.SetBool ("Caminar", true);
			} else {
				animator.SetBool ("Caminar", false);
			}
				
			transform.Translate (Vector2.right * Input.GetAxis ("Horizontal") * 15 * Time.deltaTime);
			transform.Translate (Vector2.up * Input.GetAxis ("Vertical") * 15 * Time.deltaTime);

		}
		//Si termino
		else {
			animator.SetBool ("Caminar", false);
		}
			
	}
}
