using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public TMP_InputField inputField;

    public string storedText;

    void Start()
    {
        inputField.onValueChanged.AddListener(UpdateText);
    }

    public void UpdateText(string text)
    {
        storedText = text; // Store the text
    }

    private void Awake()
    {
        // Ensure only one instance of the MainManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this GameObject
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
