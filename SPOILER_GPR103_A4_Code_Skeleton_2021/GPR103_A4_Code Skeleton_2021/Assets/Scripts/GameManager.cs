using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This script is to be attached to a GameObject called GameManager in the scene. It is to be used to manager the settings and overarching gameplay loop.
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Scoring")]
    public int currentScore = 0; //The current score in this round.
    public int highScore = 0; //The highest score achieved either in this session or over the lifetime of the game.
    public TMP_Text currentScoreUI;
    public TMP_Text currentLivesUI;
    public TMP_Text highScoreUI;
    public int maxLives = 5;
    public int currentLives = 5;
    public int minLives = 0;

    [Header("Playable Area")]
    public float levelConstraintTop; //The maximum positive Y value of the playable space.
    public float levelConstraintBottom; //The maximum negative Y value of the playable space.
    public float levelConstraintLeft; //The maximum negative X value of the playable space.
    public float levelConstraintRight; //The maximum positive X value of the playablle space.

    [Header("Gameplay Loop")]
    public bool isGameRunning; //Is the gameplay part of the game current active?
    public float totalGameTime; //The maximum amount of time or the total time avilable to the player.
    public float gameTimeRemaining; //The current elapsed time

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(-currentScore);
        currentScoreUI.text = "0";

        UpdateLives(0);
        currentLivesUI.text = "5";
        
        
        UpdateHighScore(0);
        highScoreUI.text = "0";
       
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHighScore(0);
    }

    public void UpdateScore(int scoreAmount)
    {
        currentScore += scoreAmount;
        currentScoreUI.text = currentScore.ToString();
    }

    public void UpdateLives(int livesRemaining)
    {
        currentLives += livesRemaining;
        currentLivesUI.text = currentLives.ToString();
    }

    void UpdateHighScore(int currentHighScore)
    {
        highScore += currentHighScore;
        highScoreUI.text = highScore.ToString();
        if (currentScore >= highScore)
        {
            highScore = currentScore;
        }

    }
}

