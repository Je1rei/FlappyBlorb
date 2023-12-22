using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class LogicScript : MonoBehaviour
{
    private int _highScore;

    public int playerScore;
    public int scoreToAdd;
    public int ratioSpeed;

    public Text scoreText;
    public Text highScoreText;
    public Text ratioSpeedText;
    public Text finalScoreRoundText;

    public GameObject gameOverScreen;

    public AudioSource dingSFX;
    public AudioSource swingSFX;
    public AudioSource deadSFX;

    void Start()
    {
        LoadSaves();
    }

    [ContextMenu("Increase Score")]
    public void AddScore()
    {
        if (gameOverScreen != null && !gameOverScreen.activeInHierarchy)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            dingSFX.Play();
        }
    }

    public void GameOver()
    {
        finalScoreRoundText.text = playerScore.ToString();
        SaveScore();
        deadSFX.Play();
        gameOverScreen.SetActive(true);
    }

    public void LoadSaves()
    {
        ratioSpeed = SaveLoadManager.LoadRatioSpeed();

        if(ratioSpeed == 0)
        {
            ratioSpeed = 1;
        }

        if (ratioSpeedText != null)
        {
            ratioSpeedText.text = ratioSpeed.ToString() + "X";
        }

        _highScore = SaveLoadManager.LoadHighScore();
        highScoreText.text = _highScore.ToString();
    }

    public void SaveScore()
    {
        if (playerScore > _highScore)
        {
            SaveLoadManager.SaveHighScore(playerScore);
        }
    }

    public void DeleteSaves()
    {
        SaveLoadManager.DeleteSaves();
        LoadSaves();
    }

    public void DoubleRatioSpeed()
    {
        if (ratioSpeed <= 10 && ratioSpeed != 0)
        {
            ratioSpeed *= 2;
        }
        else
        {
            ratioSpeed = 1;
        }

        SaveLoadManager.SaveRatioSpeedGame(ratioSpeed);
        LoadSaves();
    }
}
