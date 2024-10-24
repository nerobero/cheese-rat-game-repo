using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public CanvasGroup OptionPanel;

    void Start()
    {
        OptionPanel.alpha = 0;
        OptionPanel.blocksRaycasts = false;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Option()
    {
        OptionPanel.alpha = 1;
        OptionPanel.blocksRaycasts = true;
        OptionPanel.interactable = true;
    }

    public void Back()
    {
        OptionPanel.alpha = 0;
        OptionPanel.blocksRaycasts = false;
        OptionPanel.interactable = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
