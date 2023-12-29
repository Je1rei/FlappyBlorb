using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class LogicScript : MonoBehaviour
{
    private const int firstRate = 1;
    private const int secondRate = 2;
    private const int thirdRate = 4;
    private const int fourthRate = 8;
    private const int fifthRate = 16;

    private string _highScoreName = "HighScore";
    private int _highScore;

    public int gameMode = 0;

    public int playerScore;
    public int scoreToAdd;
    public int ratioSpeed;

    public Text gameModeText;
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
        SaveHighScore();
        deadSFX.Play();
        gameOverScreen.SetActive(true);
    }

    public void LoadSaves()
    {
        ratioSpeed = SaveLoadManager.LoadParam("RatioSpeed");
        gameMode = SaveLoadManager.LoadParam("GameMode");

        ToogleTextMode();

        if (ratioSpeed == 0)
        {
            ratioSpeed = 1;
        }

        if (ratioSpeedText != null)
        {
            ratioSpeedText.text = ratioSpeed.ToString() + "X";
        }

        _highScore = CheckHighScoreSaves();
        highScoreText.text = _highScore.ToString();
    }

    public void SaveHighScore()
    {
        if (playerScore > _highScore)
        {
            SaveLoadManager.SaveParam(_highScoreName, playerScore);
        }
    }

    public void DeleteHighScore()
    {
        SaveLoadManager.DeleteParam(_highScoreName);
        LoadSaves();
    }

    public void DeleteSpeedRatio()
    {
        SaveLoadManager.DeleteParam("RatioSpeed");
        LoadSaves();
    }

    public void DeleteGameMode()
    {
        SaveLoadManager.DeleteParam("GameMode"); 
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

        SaveLoadManager.SaveParam("RatioSpeed", ratioSpeed);
        LoadSaves();
    }

    public void ChangeCollider()
    {
        int newRadius = 1;

        BirdScript birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        birdScript.ChangeCollider(newRadius);
    }

    public int LoadHighScore(string namePrefs)
    {
        if (PlayerPrefs.HasKey(namePrefs))
        {
            return _highScore = SaveLoadManager.LoadParam(namePrefs);
        }

        return 0;
    }

    public void ToogleTextMode()
    {
        if (gameMode == 0)
        {
            if (gameModeText != null)
            {
                gameModeText.text = "DEFAULT";
            }
        }
        else
        {
            if (gameModeText != null)
            {
                gameModeText.text = "MOVE PIPES";
            }
        }
    }

    public void ToogleBool()
    {
        if (gameMode == 0)
        {
            if (gameModeText != null)
            {
                gameModeText.text = "MOVE PIPES";
            }

            gameMode = 1;

        }
        else
        {
            if (gameModeText != null)
            {
                gameModeText.text = "DEFAULT";
            }

            gameMode = 0;
        }

        SaveLoadManager.SaveParam("GameMode", gameMode);
    }

    private int CheckHighScoreSaves()
    {
        int highScore = 0;

        if(highScoreText != null)
        {
            switch (ratioSpeed)
            {
                case firstRate:
                    _highScoreName = "HighScore";
                    highScore = LoadHighScore(_highScoreName);
                    break;

                case secondRate:
                    _highScoreName = "HighScore2X";
                    highScore = LoadHighScore(_highScoreName);
                    break;

                case thirdRate:
                    _highScoreName = "HighScore4X";
                    highScore = LoadHighScore(_highScoreName);
                    break;

                case fourthRate:
                    _highScoreName = "HighScore8X";
                    highScore = LoadHighScore(_highScoreName);
                    break;

                case fifthRate:
                    _highScoreName = "HighScore16X";
                    highScore = LoadHighScore(_highScoreName);
                    break;
            }
        }

        return highScore;
    }
}
