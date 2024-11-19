using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text levelText;
    public Text maxScoreText;  // 최대 스코어 텍스트
    private int score = 0;  // 점수 초기화
    private int level = 1;  // 레벨 초기화
    private const int maxLevel = 15;  // 최대 레벨
    private int maxScore = 0;  // 최대 스코어 초기화

    void Start()
    {
        // 게임 시작 시 최대 스코어를 불러옵니다.
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
        // 게임 시작 시 점수와 레벨 텍스트를 갱신합니다.
        UpdateScoreText();
        UpdateLevelText();
        UpdateMaxScoreText();
    }

    void Update()
    {
        // 주기적으로 텍스트를 갱신합니다.
        scoreText.text = "Score: " + score.ToString();
        levelText.text = "Level: " + level.ToString();
        maxScoreText.text="MaxScore: "+maxScore.ToString();
    }

    // 점수를 증가시키는 메소드
    public void IncreaseScore()
    {
        score++;  // 점수 1 증가

        // 점수가 10의 배수이면 레벨을 증가시킵니다.
        if (score % 10 == 0 && level < maxLevel)
        {
            level++;  // 레벨 증가
            UpdateLevelText();
        }

        // 최대 스코어 업데이트
        if (score > maxScore)
        {
            maxScore = score;
            // 새로운 최대 스코어를 저장합니다.
            PlayerPrefs.SetInt("MaxScore", maxScore);
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
