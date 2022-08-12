using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buttons : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TextMeshProUGUI highscoreText;
    private void Start() {
        if (GameManager.Instance.username != "")
        {
            usernameInput.text = GameManager.Instance.username;
        }
        if (GameManager.Instance.highscoreUser != "")
        {
            highscoreText.gameObject.transform.position = new Vector3(highscoreText.gameObject.transform.position.x, 457);
            highscoreText.text = $"Highscore :  {GameManager.Instance.highscore}\nby {GameManager.Instance.highscoreUser} ";
        }
        else
        {
            highscoreText.gameObject.transform.position = new Vector3(highscoreText.gameObject.transform.position.x, 429);
            highscoreText.text = "Highscore : 0";
        }
    }
    public void Play()
    {
        GameManager.Instance.Play();
    }

    public void Exit()
    {
        GameManager.Instance.Exit();
    }

    public void Username(string playerName)
    {
        if (playerName.Length > 12)
        {
            playerName = playerName.Substring(0,12);
            usernameInput.text = playerName;
        }
        GameManager.Instance.GetPlayerName(playerName);
    }
}