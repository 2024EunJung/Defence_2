using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text levelText;
    public Text maxScoreText;
    private int score = 0;  // ���� �ʱ�ȭ
    public int level = 1;  // ���� �ʱ�ȭ
    private const int maxLevel = 15;  // �ִ� ����
    private int maxScore = 0;  // �ִ� ���ھ� �ʱ�ȭ

    void Start()
    {
        // ���� ���� �� �ִ� ���ھ �ҷ��ɴϴ�.
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
            PlayerPrefs.SetInt("MaxScore", maxScore);  // ���ο� �ִ� ���ھ� ����
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
