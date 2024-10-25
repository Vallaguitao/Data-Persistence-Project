using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;

    void Start()
    {
        inputField.onValueChanged.AddListener(UpdateText);
    }

    public void UpdateText(string text)
    {
        InputManager.Instance.storedText = text; // Store the text
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
