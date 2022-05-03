using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instence;

    public string Name;
    public int Score;

    private void Awake()
    {
        if (Instence != null)
        {
            Destroy(gameObject);
            return;
        }
        Instence = this;
        DontDestroyOnLoad(gameObject);

    }
    [Serializable]
    class SaveData
    {
        public string Name;
        public string Score;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.Name = Name;
        data.Score = Score.ToString();

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Name = data.Name;
            Score = Convert.ToInt32(data.Score);
        }
    }
}
