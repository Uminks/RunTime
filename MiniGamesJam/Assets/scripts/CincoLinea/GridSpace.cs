using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {
	public Button button;   //Todos los botones a los que se le asigne GridSpace
	public Text buttonText;
	public Sprite buttonSprite_1;
	public Sprite buttonSprite_2;
	public Sprite buttonSprite_3;
	private GameController gameController;//Controlador de juego

	public void setSpace(){
		
		if (gameController.getPlayerSide () == "x") {//Turno 1
			buttonText.text = gameController.getPlayerSide();
			button.GetComponent<Image>().sprite=  buttonSprite_1;//Asigino sprite player1
		}

		else if (gameController.getPlayerSide () == "o") {//Turno 2
			buttonText.text = gameController.getPlayerSide();
			button.GetComponent<Image>().sprite=  buttonSprite_2;//Asigino sprite player2
		}

		else if (gameController.getPlayerSide () == "y") {//Turno 3
			buttonText.text = gameController.getPlayerSide();
			button.GetComponent<Image>().sprite=  buttonSprite_3;//Asigino sprite player2
		}

		button.interactable = false; //Inabilito botón
		gameController.EndTurn();//Finaliza Turno
	}

	public void setgameControllerReference(GameController controller){
		gameController = controller;
	}


}
