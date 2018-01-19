using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {

	public float velocidad;
	public float velocidad_max; 
	public Estados score;

	private Rigidbody2D player;
	private Animator anim;
	private AudioSource audio;

	void Start () {
		player = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
	}


	void FixedUpdate () {
		anim.SetFloat ("Speed", Mathf.Abs (player.velocity.x));

		float h = Input.GetAxis ("Horizontal");
		float limite_velocidad = Mathf.Clamp (player.velocity.x, -velocidad_max, velocidad_max);
		player.AddForce(Vector2.right * velocidad * h);
		player.velocity = new Vector2 (limite_velocidad, player.velocity.y);

		if (h > 0) {
			transform.localScale = new Vector3 (-0.4f, 0.4f, 0.4f);
		} else {
			transform.localScale = new Vector3 (0.4f, 0.4f, 0.4f);
		}


	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag == "good") {
			audio.Play ();
			score.puntos ();
			Destroy(col.gameObject);

		}
		if (col.transform.tag == "bad") {
			score.inflacion ();
			score.restPunto ();
			Destroy (col.gameObject);
		}
	}

}
