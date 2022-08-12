using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string username;
    public int highscore;
    public string highscoreUser;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        highscore = 0;
        highscoreUser = "";
        username = "";
        LoadData();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Exit()
    {
        SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif        
    }

    public void Play()
    {
        if (username == "")
        {
            username = "unnamedUser";
        }
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete) & SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (GameManager.Instance.username == "unnamedUser")
            {
                GameManager.Instance.username = "";
            }
            SceneManager.LoadScene(0);
        }
    }

    public void GetPlayerName(string playerName)
    {
        username = playerName;
    }

    [System.Serializable]
    class DataThatWillBeSaved
    {
        public int highscore;
        public string highscoreUser;
    }

    public void SaveData()
    {
        DataThatWillBeSaved data = new DataThatWillBeSaved();

        data.highscore = highscore;
        data.highscoreUser = highscoreUser;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savedata.json",json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataThatWillBeSaved data = JsonUtility.FromJson<DataThatWillBeSaved>(json);

            highscore = data.highscore;
            highscoreUser = data.highscoreUser;
        }
    }

}
