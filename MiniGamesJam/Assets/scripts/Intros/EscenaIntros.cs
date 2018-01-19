using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscenaIntros : MonoBehaviour {

	public GameObject[] textos;
	public string nextScene;
	private int o = 0;

	void Start () {
		for (int i = 0; i < textos.Length; i++) {
			if (i != 0) {
				textos [i].SetActive (false);
			}
		}
		textos [o].SetActive (true);
	}
	
	public void siguienteMensaje(){
		if (o == (textos.Length-1)) {
			SceneManager.LoadScene (nextScene);
		}

		if (o <= (textos.Length-2)) {
			textos [o].SetActive (false);
			textos [++o].SetActive (true);
		}

		if (o  == (textos.Length-1)) {
			this.GetComponentInChildren<Text>().text = "Go!";
		}
	}
}
