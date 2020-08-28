using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    //public int totalScore=0;
    //public Text scoreText;

    public string startGame = "lvl_1";

    public static GameController instance;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //LoadScore();
    }

    /*public void updateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }*/

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void StartGame()
    {
        //SaveScore(0);
        SceneManager.LoadScene(startGame);
    }

    public void QuitGame()
    {
       Application.Quit();
    }
    /*public void SaveScore(int score)
    {
        PlayerPrefs.SetInt("score",score);
    }
    public void LoadScore()
    {
        totalScore += PlayerPrefs.GetInt("score");
        updateScoreText();
    }*/
}
