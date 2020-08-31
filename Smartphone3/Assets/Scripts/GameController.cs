using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private const bool V = true;

    //public int totalScore=0;
    //public Text scoreText;

    public string startGame = "lvl_1";

    public static GameController instance;
    public Text time;

    public GameObject gameOver;
    public float timer;
    private float oldTimer;
    bool isOver = false;
    bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        oldTimer = timer; 
    }
    void Update()
    {
        if(!isOver)
        {
            if(timer < 0)
            {
                isRunning = false;
            }
            if(isRunning)
            {
                timer -= Time.deltaTime;
                time.text = "Time: " + timer;
            }
            else
            {
                ShowGameOver();
            }
        }
    }


    public void ShowGameOver()
    {
        isOver = true;
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startGame);
    }

    public void QuitGame()
    {
       Application.Quit();
    }
}
