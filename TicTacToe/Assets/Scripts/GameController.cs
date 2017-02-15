using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
    public Button button;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour {
    public GridSpace[] buttonList;
    public Text gameOverText;

    private int moveCount;
    private string playerSide;
    public GameObject gameOverPanel;
    public GameObject restartButton;
    public GameObject startInfo;

    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;

    private AI artificialIntelligence;

    private void Awake()
    {
        Debug.Log("Begin: Awake");
        this.SetGameControllerReferenceOnButtons();
        this.moveCount = 0;
        this.gameOverPanel.SetActive(false);
        this.restartButton.SetActive(false);
        this.artificialIntelligence = new AI("Herbert");
        Debug.Log("End: Awake");
    }

    private void SetPlayerButtons(bool toggle)
    {
        Debug.Log("Begin: SetPlayerButtons");
        this.playerX.button.interactable = toggle;
        this.playerO.button.interactable = toggle;
        Debug.Log("End: SetPlayerButtons");
    }

    private void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        Debug.Log("Begin: SetPlayerColors");
        newPlayer.panel.color = this.activePlayerColor.panelColor;
        newPlayer.text.color = this.activePlayerColor.textColor;
        oldPlayer.panel.color = this.inactivePlayerColor.panelColor;
        oldPlayer.text.color = this.inactivePlayerColor.textColor;
        Debug.Log("End: SetPlayerColors");
    }

    private void SetGameControllerReferenceOnButtons()
    {
        Debug.Log("Begin: SetGameControllerReferenceOnButtons");
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
        Debug.Log("End: SetGameControllerReferenceOnButtons");
    }

    public string GetPlayerSide()
    {
        Debug.Log("Begin: GetPlayerSide");
        return this.playerSide;
    }

    public void EndTurn()
    {
        Debug.Log("Begin: EndTurn");
        moveCount++;

        if (buttonList[0].buttonText.text == this.playerSide 
            && buttonList[1].buttonText.text == this.playerSide 
            && buttonList[2].buttonText.text == this.playerSide)
        {
            this.GameOver(this.playerSide);
        }

        else if (buttonList[3].buttonText.text == this.playerSide
            && buttonList[4].buttonText.text == this.playerSide
            && buttonList[5].buttonText.text == this.playerSide)
        {
            this.GameOver(this.playerSide);
        }

        else if (buttonList[6].buttonText.text == this.playerSide
            && buttonList[7].buttonText.text == this.playerSide
            && buttonList[8].buttonText.text == this.playerSide)
        {
            this.GameOver(this.playerSide);
        }

        else if (buttonList[0].buttonText.text == this.playerSide
            && buttonList[3].buttonText.text == this.playerSide
            && buttonList[6].buttonText.text == this.playerSide)
        {
            this.GameOver(this.playerSide);
        }

        else if (buttonList[1].buttonText.text == this.playerSide
            && buttonList[4].buttonText.text == this.playerSide
            && buttonList[7].buttonText.text == this.playerSide)
        {
            this.GameOver(this.playerSide);
        }

        else if (buttonList[2].buttonText.text == this.playerSide
            && buttonList[5].buttonText.text == this.playerSide
            && buttonList[8].buttonText.text == this.playerSide)
        {
            this.GameOver(this.playerSide);
        }

        else if (buttonList[0].buttonText.text == this.playerSide
            && buttonList[4].buttonText.text == this.playerSide
            && buttonList[8].buttonText.text == this.playerSide)
        {
            this.GameOver(this.playerSide);
        }

        else if (buttonList[2].buttonText.text == this.playerSide
            && buttonList[4].buttonText.text == this.playerSide
            && buttonList[6].buttonText.text == this.playerSide)
        {
            this.GameOver(this.playerSide);
        }

        else if (moveCount >= 9)
        {
            this.GameOver("It's a draw!");
            SetPlayerColorsInactive();
        }
        else
        {
            this.ChangeSides();
        }
        Debug.Log("End: EndTurn");
    }

    private string HumanSide;
    private string AiSide;

    public void SetStartingSide(string startingSide)
    {
        Debug.Log("Begin: SetStartingSide");
        this.playerSide = startingSide;
        this.HumanSide = startingSide;

        if (playerSide == "X")
        {
            this.SetPlayerColors(playerX, playerO);
            this.AiSide = "O";
        }
        else
        {
            this.SetPlayerColors(playerO, playerX);
            this.AiSide = "X";
        }

        this.StartGame();
        Debug.Log("End: SetStartingSide");
    }

    private void ChangeSides()
    {
        Debug.Log("Begin: ChangeSides");
        this.playerSide = (playerSide == "X") ? "O" : "X";

        if (playerSide == "X")
        {
            this.SetPlayerColors(playerX, playerO);
        }
        else
        {
            this.SetPlayerColors(playerO, playerX);
        }

        if(this.playerSide == this.AiSide)
        {
            var move = this.artificialIntelligence.Move(this.buttonList);
            this.buttonList[move].SetSpace();
        }

        Debug.Log("End: ChangeSides");
    }

    private void SetGameOverText(string value)
    {
        Debug.Log("Begin: SetGameOverText");
        this.gameOverPanel.SetActive(true);
        this.gameOverText.text = value;
        Debug.Log("End: SetGameOverText");
    }

    private void GameOver(string winningPlayer)
    {
        Debug.Log("Begin: GameOver");
        this.SetBoardInteractable(false);
        this.restartButton.SetActive(true);

        if (winningPlayer == "draw")
        {
            this.SetGameOverText("It's a Draw!");
        }
        else
        {
            this.SetGameOverText(winningPlayer + " Wins!");
        }
        Debug.Log("End: GameOver");
    }

    private void SetPlayerColorsInactive()
    {
        Debug.Log("Begin: SetPlayerColorsInactive");
        this.playerX.panel.color = inactivePlayerColor.panelColor;
        this.playerX.text.color = inactivePlayerColor.textColor;
        this.playerO.panel.color = inactivePlayerColor.panelColor;
        this.playerO.text.color = inactivePlayerColor.textColor;
        Debug.Log("End: SetPlayerColorsInactive");
    }

    private void StartGame()
    {
        Debug.Log("Begin: StartGame");
        this.SetBoardInteractable(true);
        this.SetPlayerButtons(false);
        this.startInfo.SetActive(false);
        Debug.Log("End: StartGame");
    }

    public void RestartGame()
    {
        Debug.Log("Begin: RestartGame");
        this.moveCount = 0;
        this.gameOverPanel.SetActive(false);

        foreach (var button in this.buttonList)
        {
            button.buttonText.text = string.Empty;
        }
        this.SetPlayerButtons(true);
        this.restartButton.SetActive(false);
        this.SetPlayerColorsInactive();
        startInfo.SetActive(true);
        Debug.Log("End: RestartGame");
    }

    private void SetBoardInteractable(bool toggle)
    {
        Debug.Log("Begin: SetBoardInteractable");
        foreach (var button in this.buttonList)
        {
            button.GetComponentInParent<Button>().interactable = toggle;
        }
        Debug.Log("End: SetBoardInteractable");
    }
}
