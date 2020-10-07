using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject scoreUI;
    public Text finalScore;

    // Update is called once per frame
    public void playerDeathWatch(bool isDead)
    {
        if(isDead)
        {
            scoreUI.SetActive(false);
            gameOverUI.SetActive(true);
            Cursor.visible = true;
        }
        else
        {
            gameOverUI.SetActive(false);
        }
    }

    public void setFinalScore(int endScore)
    {
        finalScore.text = "SCORE: " + endScore;
    }

    public void playAgain()
    {
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void quit()
    {
        Application.Quit();
    }
}
