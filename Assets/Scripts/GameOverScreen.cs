using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI pointsText;


    public void Setup(float timer)
    {
        // Takes time a player has survived upon death and applies it to a text element on the game over screen
        score = Mathf.FloorToInt(timer);
        pointsText.text = score.ToString() + " POINTS";
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        // Restarts the game
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameObject.SetActive(false);
    }

    public void MainManu()
    {
        // Returns to the main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
