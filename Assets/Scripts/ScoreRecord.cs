using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreRecord : MonoBehaviour
{
    public static ScoreRecord instance;

    public Record bestRecord;
    public string player;
    string path;

    private void Awake()
    {
        path = Application.persistentDataPath + "/best.json";
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);      
        loadRecord();
    }

    [Serializable]
    public class Record
    {
        public int score;
        public string bestPlayer;
    }

    public void saveRecord()
    {
        File.WriteAllText(path, JsonUtility.ToJson(bestRecord));
    }

    public void loadRecord()
    {
        if (File.Exists(path)) bestRecord = JsonUtility.FromJson<Record>(File.ReadAllText(path));
        else
        {
            bestRecord.bestPlayer = "NA";
            bestRecord.score = 0;
        }
    }
}
