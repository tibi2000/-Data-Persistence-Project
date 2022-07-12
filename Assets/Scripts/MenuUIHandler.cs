using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameField;

    public void StartGame()
    {
        if (nameField.text == "")
        {
            DataManager.instance.currentPlayerName = "Guest";
        }
        else
        {
            DataManager.instance.currentPlayerName = nameField.text;
        }
        SceneManager.LoadScene(1);
    }
}
