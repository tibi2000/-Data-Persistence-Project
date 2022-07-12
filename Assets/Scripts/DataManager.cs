using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public string currentPlayerName;

    public string bestPlayerName;
    public int bestScore = 0;

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadRecord();
    }

    public void UpdateBestRecord(int score)
    {
        if (score > bestScore)
        {
            bestPlayerName = currentPlayerName;
            bestScore = score;
        }

        SaveRecord();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int bestScore;
    }

    public void SaveRecord()
    {
        SaveData saveData = new SaveData();
        saveData.bestPlayerName = bestPlayerName;
        saveData.bestScore = bestScore;

        string json_data = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json_data);
    }

    public void LoadRecord()
    {
        string f_path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(f_path))
        {
            string json_data = File.ReadAllText(f_path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json_data);

            bestPlayerName = saveData.bestPlayerName;
            bestScore = saveData.bestScore;
        }
    }
}
