using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text levelText;
    public Text maxScoreText;
    private int score = 0;  // 점수 초기화
    public int level = 1;  // 레벨 초기화
    private const int maxLevel = 15;  // 최대 레벨
    private int maxScore = 0;  // 최대 스코어 초기화

    void Start()
    {
        // 게임 시작 시 최대 스코어를 불러옵니다.
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
        UpdateScoreText();
        UpdateLevelText();
        UpdateMaxScoreText();
    }

    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        levelText.text = "Level: " + level.ToString();
        maxScoreText.text = "Max Score: " + maxScore.ToString();
    }

    public void IncreaseScore()
    {
        score++;

        if (score % 10 == 0 && level < maxLevel)
        {
            level++;
            UpdateLevelText();
        }

        if (score > maxScore)
        {
            maxScore = score;
            PlayerPrefs.SetInt("MaxScore", maxScore);  // 새로운 최대 스코어 저장
            PlayerPrefs.Save();
            UpdateMaxScoreText();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    private void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + level.ToString();
        }
    }

    private void UpdateMaxScoreText()
    {
        if (maxScoreText != null)
        {
            maxScoreText.text = "Max Score: " + maxScore.ToString();
        }
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetMaxScore()
    {
        return maxScore;
    }
}
