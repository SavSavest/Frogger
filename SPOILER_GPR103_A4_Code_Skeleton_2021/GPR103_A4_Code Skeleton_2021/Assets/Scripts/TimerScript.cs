using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public Slider timerSlider;
    public float maxGameTime;
    public float minGameTime;
    private bool stopTimer;
    public float timer = 0.00f;
    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = maxGameTime;
        timerSlider.value = maxGameTime;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;   
        float time = maxGameTime - timer;       
        int minutes = Mathf.FloorToInt(time / 60);
        int second = Mathf.FloorToInt(time - minutes * 60f);
       
        if (time <= minGameTime)
        {
            stopTimer = true;
            GameOver();
        }

        if (stopTimer == false)
        {
            timerSlider.value = time;
        }
    }

    void GameOver()    
    {
        
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}


//Reference
//https://www.youtube.com/watch?v=S12x7txHS1c&t=426s&ab_channel=CatoDevs-Unity%26RTutorials
