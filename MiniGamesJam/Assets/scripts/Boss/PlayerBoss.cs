using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBoss : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator animator;

	private GameObject maduro;
	private GameObject CabezaMaduro;
	public GameObject[] pisosMaduro;

	public GameObject panelGanar;

	public float forceJump = 500f;
	private bool isWalking;
	private bool isFloor;
	private float speed = 3f;

	private bool terminar;
	private int cont = 0;

	private PriceHieloGrafo price;

	public AudioSource jumpEffect;
	public AudioSource palanca;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		maduro = GameObject.Find ("Boss");
		CabezaMaduro = GameObject.Find ("Cabeza");
		terminar = false;

		price = GameObject.FindObjectOfType<PriceHieloGrafo> ();
		panelGanar.SetActive (false);

		jumpEffect = GetComponent<AudioSource> ();
	}
		

	/// 
	/// Colisiones con componentes especificos
	/// 
	/// 
	void OnCollisionEnter2D(Collision2D obj){
		////
		/// Colision con el piso
		/// 
		if(obj.transform.tag == "floor"){
			isFloor = true;
		}
		else if(obj.transform.name == "Izquierdo" || obj.transform.name == "Derecho"){
			isWalking = false;
		}

		///
		///PISOS DE MADURO
		/// 
		if (obj.transform.name == "PalancaRef1") {
			if (pisosMaduro [0] != null) {
				palanca.Play ();
				pisosMaduro [0].SetActive(false);
				obj.transform.rotation = Quaternion.Euler (0, 180, 0);
				obj.transform.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
				cont++;
			}
		}

		if (obj.transform.name == "PalancaRef2") {
			if (pisosMaduro [1] != null) {
				palanca.Play ();
				pisosMaduro [1].SetActive(false);
				obj.transform.rotation = Quaternion.Euler (0, 180, 0);
				obj.transform.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
				cont++;
			}
		}

		if (obj.transform.name == "PalancaRef3") {
			if (pisosMaduro [2] != null) {
				palanca.Play ();
				pisosMaduro [2].SetActive(false);
				obj.transform.rotation = Quaternion.Euler (0, 180, 0);
				obj.transform.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
				cont++;
			}
		}

		if (obj.transform.name == "PalancaRef4") {
			if (pisosMaduro [3] != null) {
				palanca.Play ();
				pisosMaduro [3].SetActive(false);
				obj.transform.rotation = Quaternion.Euler (0, 180, 0);
				obj.transform.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
				cont++;
			}
		}

		///
		///Disparo
		/// 
		if (obj.transform.tag == "Pared") {
			Destroy (obj.transform.gameObject);
			SceneManager.LoadScene ("Boss");
		}
	}



	void Update () {

		if (!terminar) {
			////
			/// Comprobar anulacion del piso de maduro
			/// 
			if (cont == 4) {
				maduro.GetComponent<Animator> ().SetTrigger ("muerteMaduro");
				terminar = true;
			}


			///
			///Salto
			///
			if (Input.GetKeyDown (KeyCode.UpArrow) && isFloor) {
				jumpEffect.Play ();
				rb.AddForce (new Vector2 (0, forceJump));
				isFloor = false;
			}

			////
			///  Mover el personaje a la Derecha 
			/// 
			if ((Input.GetAxis ("Horizontal") > 0) && isFloor) {
				animator.SetBool ("Caminar", true);
				speed = 3;
				isWalking = true;
			}


			////
			///  Mover el personaje a la Izquierda 
			/// 
			if ((Input.GetAxis ("Horizontal") < 0) && isFloor) {
				animator.SetBool ("Caminar", true);
				speed = -3;
				isWalking = true;
			}
				

			/// 
			////
			/// Stop
			///  
			if (Input.GetAxis ("Horizontal") == 0 && Input.GetAxis ("Vertical") == 0) {
				animator.SetBool ("Caminar", false);
				isWalking = false;
			}


			////
			/// Si cae en el vacio
			/// 
			if (this.transform.position.y <= -5) {
				SceneManager.LoadScene ("Boss");
			}

			////
			/// Desplazarse
			/// 
			if (isWalking) {
				rb.velocity = new Vector2 (speed, rb.velocity.y);
			}

		}


		///
		///Comprobando salida de la cabeza de maduro del mapa 
		/// para finalizar Juego
		///
		if (maduro != null && CabezaMaduro.transform.position.y < -10) {
			Destroy (maduro);
			price.stop = true;
			panelGanar.SetActive (true);
		}
	}


}
