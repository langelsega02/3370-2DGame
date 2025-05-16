using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject winPanel;

    public Text highscoreText;
    public Text goalText;
    public Text timeText;

    int score = 0;             // Coins collected this level
    int totalCoins = 0;        // NEW: Cumulative coins across all levels
    int highscore = 0;         // Highest total coins collected in a run
    int goal = 10;
    float timeLeft = 60.0f;
    bool isGamePaused = false;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore", 0); // Load saved high score
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        UpdateGoalText();
        UpdateTimeText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))  // Press H to reset highscore
        {
            PlayerPrefs.DeleteKey("HighScore");
            PlayerPrefs.Save();
            Debug.Log("Highscore reset!");
            highscore = 0;
            highscoreText.text = "HIGHSCORE: 0";
        }

        if (!isGamePaused)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimeText();
                Debug.Log("Updated Timer: " + timeLeft);
            }
            else
            {
                Debug.Log("Time's up!");
                // Optional: End run or trigger lose screen here
            }
        }
    }

    void UpdateGoalText()
    {
        if (goalText != null)
        {
            goalText.text = score.ToString() + " / " + goal.ToString();
        }
        else
        {
            Debug.LogWarning("Goal Text is not assigned!");
        }
    }

    void UpdateTimeText()
    {
        if (timeText != null)
        {
            timeText.text = "TIME: " + Mathf.CeilToInt(timeLeft).ToString();
        }
        else
        {
            Debug.LogWarning("Time Text is not assigned!");
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        totalCoins += amount;  // ✅ Add to cumulative score
        UpdateGoalText();

        if (totalCoins > highscore)
        {
            highscore = totalCoins;
            highscoreText.text = "HIGHSCORE: " + highscore.ToString();
            PlayerPrefs.SetInt("HighScore", highscore);
            PlayerPrefs.Save();
        }

        if (score >= goal)
        {
            Debug.Log("Goal achieved!");
            ShowWinPanel();
        }
    }

    void ShowWinPanel()
    {
        Time.timeScale = 0f;
        winPanel.SetActive(true);
        isGamePaused = true;
    }

    public void OnContinue()
    {
        Time.timeScale = 1f;
        isGamePaused = false;

        timeLeft = 60f;
        goal += 10;
        score = 0;  // ✅ Reset only this level's score

        UpdateGoalText();
        UpdateTimeText();

        winPanel.SetActive(false);
        Debug.Log("Timer reset to: " + timeLeft);
    }

    public float GetTimeLeft()
    {
        return timeLeft;
    }

    // Optional: Call this from a full game reset if needed
    public void ResetTotalScore()
    {
        totalCoins = 0;
    }
}
