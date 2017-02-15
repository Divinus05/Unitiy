using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour {

    public Button button;
    public Text buttonText;

    public void Switch()
    {
        Debug.Log("Switch to: " + this.buttonText.text);
        SceneManager.LoadScene(this.buttonText.text);
    }
}
