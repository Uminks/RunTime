using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {

	public GameObject[] obj;
	public float tiempo_min = 1f;
	public float tiempo_max = 2f;

	// Use this for initialization
	void Start () {
		generador ();
		mover ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void generador(){
		Instantiate(obj[Random.Range(0,obj.Length)], transform.position , Quaternion.identity);
		Invoke ("generador", tiempo_max);
	}

	void mover(){
		transform.position = new Vector3 (Random.Range (-8f, 8f),transform.position.y,transform.position.z);
		Invoke ("mover", tiempo_min);
	}
}
