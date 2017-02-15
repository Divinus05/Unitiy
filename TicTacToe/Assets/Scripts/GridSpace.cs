using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

    public Button button;
    public Text buttonText;
    private GameController gameController;

    public void SetSpace()
    {
        this.buttonText.text = this.gameController.GetPlayerSide();
        this.button.interactable = false;
        this.gameController.EndTurn();
    }

    public void SetGameControllerReference(GameController controller)
    {
        this.gameController = controller;
    }
}
