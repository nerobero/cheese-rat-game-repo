using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public CanvasGroup OptionPanel;

<<<<<<< HEAD
=======
    void Start()
    {
        OptionPanel.alpha = 0;
        OptionPanel.blocksRaycasts = false;
    }

>>>>>>> 37b889520cdaf63fa195ece8b2f87db4cb675da0
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Option()
    {
        OptionPanel.alpha = 1;
        OptionPanel.blocksRaycasts = true;
<<<<<<< HEAD
=======
        OptionPanel.interactable = true;
>>>>>>> 37b889520cdaf63fa195ece8b2f87db4cb675da0
    }

    public void Back()
    {
<<<<<<< HEAD
        OptionPanel.alpha = 1;
        OptionPanel.blocksRaycasts = false;
=======
        OptionPanel.alpha = 0;
        OptionPanel.blocksRaycasts = false;
        OptionPanel.interactable = false;
>>>>>>> 37b889520cdaf63fa195ece8b2f87db4cb675da0
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
