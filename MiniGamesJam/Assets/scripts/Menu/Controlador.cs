using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour {

	public void cambiar(string escena){

		SceneManager.LoadScene (escena);
	}

	public void salir(){

		Application.Quit();

	}




}
