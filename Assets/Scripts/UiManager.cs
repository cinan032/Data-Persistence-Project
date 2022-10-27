using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text scoreText;
    public Text playerInput;

    void Start()
    {
        if (ScoreRecord.instance != null)
            scoreText.text = "Best Score: " + ScoreRecord.instance.bestRecord.bestPlayer + " : " + ScoreRecord.instance.bestRecord.score;
    }

    public void startGame()
    {
        ScoreRecord.instance.player = playerInput.text;
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
