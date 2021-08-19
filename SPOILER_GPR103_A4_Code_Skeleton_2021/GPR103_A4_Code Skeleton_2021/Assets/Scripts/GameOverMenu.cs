using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour

  {
    void Start()
    {

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Assessment4", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Game has quit.");
    }


    //Load level two from EndScene
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

