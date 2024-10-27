using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class InputManager : MonoBehaviour
{
    [Serializable]
    class SaveData
    {
        public int highestScore;
        public string highestScoreName;
    }

    public void SaveHighest()
    {
        SaveData data = new SaveData();
        data.highestScore = storedScore;
        data.highestScoreName = highestScoreName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighest()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            storedScore = data.highestScore;
            highestScoreName = data.highestScoreName;
        }
    }

    public static InputManager Instance;

    public string storedText;
    public string highestScoreName;
    public int storedScore;

    private void Awake()
    {
        LoadHighest();
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
}
