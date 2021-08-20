using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
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

// references
// https://www.google.com/search?q=how+to+mkae+a+menu+screen+in+unity&rlz=1C1AVFA_enAU742AU742&oq=how+to+mkae+a+menu+screen+in+unity&aqs=chrome..69i57j0i13l6j0i22i30j0i390.4684j0j7&sourceid=chrome&ie=UTF-8#kpvalbx=_fIHjYLHcGrOymgeOi5CADg31
// https://www.google.com/search?q=how+to+set+up+a+menu+in+unity+c%23&rlz=1C1AVFA_enAU742AU742&oq=how+to+set+up+a+menu+in+unity+c%23&aqs=chrome..69i57j33i160l4.7032j0j7&sourceid=chrome&ie=UTF-8#kpvalbx=_3cXjYJrYH9WcmgfYvqSwAg39

    
   