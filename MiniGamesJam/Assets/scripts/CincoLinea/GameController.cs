using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Text[] buttonList;//Vector del campo
	private string playerSide;
	private int change = 0;//Para cambio de Turno

	public GameObject gameOverPanel;
	public Text gameOverText;

	private bool final = false;
	private int anterior;

	private PriceCincoLinea price;


	void Awake(){//Ejecutada en primera instancia 
		gameOverPanel.SetActive(false);
		setgameControllerReferenceOnButton();//
		playerSide = "x";

		price = GameObject.Find("ControladorTxtPrice").GetComponent<PriceCincoLinea> ();
	}

	void setgameControllerReferenceOnButton(){
		for (int i = 0; i < buttonList.Length; i++) {//Recorre toda la lista
			buttonList [i].GetComponentInParent<GridSpace> ().setgameControllerReference(this);//asigna controlador al botón Presionado
		}
	}

	public string getPlayerSide(){
		return playerSide;//Retorno LLamado desde GridSpace.cs para asignar Sprite
	}

	public void EndTurn(){//Finalizar Turno (llamada desde GridSpace.cs)
			/**************Horizontales****************/
			for (int i = 0; i < buttonList.Length; i++) {

				if(i==4 || i==12 || i==20 || i==28 || i==36 || i==44 || i==52) i+=4;//Para que no salte de linea
				else if(i<60){	
					if (buttonList [i].text == playerSide && buttonList [i + 1].text == playerSide && buttonList [i + 2].text == playerSide
						&& buttonList [i + 3].text == playerSide && buttonList [i + 4].text == playerSide) {
						gameOver ();
						final = true;
					}
				}
			}

			/***************Verticales*****************/
			for (int i = 0; i < buttonList.Length; i++) {
				if (i < 32) {//Para que no desborde el vector	
					if (buttonList [i].text == playerSide && buttonList [i + 8].text == playerSide && buttonList [i + 16].text == playerSide
						&& buttonList [i + 24].text == playerSide && buttonList [i + 32].text == playerSide) {
						gameOver ();
						final = true;
					}
				}
			}

			/*************Diagonal Principal**************/
			for (int i = 0; i < buttonList.Length; i++) {

				if(i==4 || i==12 || i==20 || i==28 || i==36 || i==44 || i==52) i+=3;//Para que no salte de linea
				else if(i<32){	
					if (buttonList [i].text == playerSide && buttonList [i+8+1].text == playerSide && buttonList [i+16+2].text == playerSide
						&& buttonList [i+24+3].text == playerSide && buttonList [i+32+4].text == playerSide) {
						gameOver ();
					    final = true;
					}
				}
			}

			/*************Diagonal Inversa***************/
			for (int i = 0; i < buttonList.Length; i++) {

				if(i==0 || i==8 || i==16 || i==24) i+=4;//Para que no salte de linea
				else if(i<32){	
					if (buttonList [i].text == playerSide && buttonList [i+8-1].text == playerSide && buttonList [i+16-2].text == playerSide
						&& buttonList [i+24-3].text == playerSide && buttonList [i+32-4].text == playerSide) {
						gameOver ();
						final = true;
					}
				}
			}

		/*********** llamo changeSide() para cambiar juagador ************/
		if(!final)
			changeSide ();

	}


	void gameOver(){
		price.stop = true;
		for (int i = 0; i < buttonList.Length; i++) {//Recorre toda la lista
			buttonList [i].GetComponentInParent<Button> ().interactable = false;//asigna controlador al botón Presionado
		}

		gameOverPanel.SetActive (true);
		if (playerSide == "x")
			gameOverText.text = "You Win!";
		else if(playerSide=="o") 
			gameOverText.text = "IA Win!";
	}

	void changeSide ()//Cambio de Jugador
	{
		//x=player1 //o=player2 //y=player3
		if (change == 0) {			
			playerSide = "o";
			change = 1;

			StartCoroutine (Contando ());
			int asignacion = 0;
			bool salir = false;

			do{

				asignacion = Random.Range(0, 64);

				if(buttonList [asignacion].GetComponentInParent<GridSpace>().button.IsInteractable()){
					salir = true; 
				}

			}while(!salir);

			buttonList [asignacion].GetComponentInParent<GridSpace> ().setSpace ();
		

		} else if (change == 1) {
			playerSide = "x";
			change = 0;
		}


	}


	IEnumerator Contando(){
	
		yield return new WaitForSeconds (3);
		
	}
}//Cierre de clase