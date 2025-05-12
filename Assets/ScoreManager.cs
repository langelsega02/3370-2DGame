using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text highscoreText;
    public Text goalText;
    public Text timeText;

    int score = 0;
    int highscore = 0;
    int goal = 10;
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
        goalText.text = score.ToString() + " / " + goal.ToString();
    }

    void UpdateTimeText()
    {
        timeText.text = "TIME: " + Mathf.CeilToInt(timeLeft).ToString();
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
        }
    }
}
