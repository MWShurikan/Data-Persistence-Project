using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public string highScoreName;
    public int highScore;

    public void Awake()
    {
        LoadScore();
    }

    public bool setNewHighScore(string playername, int newScore)
    {
        if (newScore > highScore)
        {
            highScoreName = playername;
            highScore = newScore;
            setHighScoreText();
            SaveScore();

            return true;
        }
        return false;
    }

    public void setHighScoreText()
    {
        Text playerNameInputField = GameObject.Find("HighScoreText").GetComponent<Text>();
        if (highScore > 0)
        {
            playerNameInputField.text = "Best Score: " + highScoreName + " ==> " + highScore;
        } else
        {
            playerNameInputField.text = "Currently, there is no high Score!";
        }
        
    }

    [System.Serializable]
    private class SaveData
    {
        public int highScore;
        public string playerName;
    }

    private void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerName = highScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.playerName;
        }
    }
}
