using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject winPanel;
    public ScoreManager scoreManager;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Instructions()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void OnContinue()
    {
        // Hide the win panel and resume the game
        winPanel.SetActive(false);
        Time.timeScale = 1f;  // Resume the game

        // Call the OnContinue() method in the ScoreManager to reset the goal and timer
        scoreManager.OnContinue();
    }
}
