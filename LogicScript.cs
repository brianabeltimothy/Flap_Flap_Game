using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScore;
    public GameObject tutorialText;
    public GameObject pipeSpawner;
    public GameObject bird;
    private Rigidbody2D birdRb2D;

    public GameObject gameOverScreen;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    private void Start()
    {
        birdRb2D = bird.GetComponent<Rigidbody2D>();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        //basically press enter before start the game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tutorialText.SetActive(false);
            pipeSpawner.SetActive(true);
            birdRb2D.gravityScale = 4.5f;
        }

        //setting the highscore
        if(playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScore.text = playerScore.ToString();
        }
    }  

    

    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void goToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
