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
    public int maxLives = 10;
    public int currentLives = 10;
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

    void Awake()
    {
        //To clear highscore before building
        //PlayerPrefs.DeleteKey("HighScore");
        //highScore = 0;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore", highScore);
            highScoreUI.text = highScore.ToString();
        }



    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(-currentScore);
        currentScoreUI.text = "0";

        UpdateLives(0);
        currentLivesUI.text = "10";     
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateHighScore();
    }

    public void UpdateScore(int scoreAmount)
    {
        UpdateHighScore();
        currentScore += scoreAmount;
        currentScoreUI.text = currentScore.ToString();
    }

    public void UpdateLives(int livesRemaining)
    {
        currentLives += livesRemaining;
        currentLivesUI.text = currentLives.ToString();      
    }

    void UpdateHighScore()
    {
       //highScore += currentHighScore;
        highScoreUI.text = highScore.ToString();
        if (currentScore > highScore)  
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

    }

}

//Reference for highscore storage
//https://www.youtube.com/watch?time_continue=855&v=0zrZZN-QaDk&feature=emb_title&ab_channel=gamesplusjames