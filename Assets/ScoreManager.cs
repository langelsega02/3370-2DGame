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

    int score = 0;
    int highscore = 0;
    int goal = 1;
    float timeLeft = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        UpdateGoalText();
        UpdateTimeText();

    }

    // Update is called once per frame
    void Update()
    {
        // Update time countdown
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimeText();
        }
        else
        {
            // Handle time's up event
            Debug.Log("Time's up!");
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
        UpdateGoalText();

        if (score > highscore)
        {
            highscore = score;
            highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        }

        if (score >= goal)
        {
            Debug.Log("Goal achieved!");
            // Add logic here for win condition
            ShowWinPanel();
        }

    }

    void ShowWinPanel()
    {
        // Pause the game and show the win panel
        Time.timeScale = 0f; // Pause the game
        winPanel.SetActive(true); // Activate the win panel
    }


    public void OnContinue()
    {
        // Reset the timer and goal after Continue is clicked
        timeLeft = 60f;  // Reset to initial time
        goal += 10;      // Increase the goal (or any other logic for goal increase)
        score = 0;       // Optionally reset score, or leave it as is
        UpdateGoalText();
        UpdateTimeText();
    }
}
