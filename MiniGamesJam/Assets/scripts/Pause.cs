using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public GameObject panelPause;

	void Start(){
		panelPause.SetActive (false);
	}

	public void pause(){
		Time.timeScale = 0;
		panelPause.SetActive (true);
	}

	public void reanudar(){
		Time.timeScale = 1;
		panelPause.SetActive (false);
	}

	public void volverMenu(){
		SceneManager.LoadScene ("Menu");
	}
}
