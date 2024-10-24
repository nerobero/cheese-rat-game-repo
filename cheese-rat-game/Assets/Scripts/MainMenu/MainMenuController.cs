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
        OptionPanel.interactable = false;
        Debug.Log("Play Game clicked");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Play Game clicked");
    }

    public void Option()
    {
        OptionPanel.alpha = 1;
        OptionPanel.blocksRaycasts = true;
        OptionPanel.interactable = true;
        Debug.Log("Play Game clicked");
    }

    public void Back()
    {
        OptionPanel.alpha = 0;
        OptionPanel.blocksRaycasts = false;
        OptionPanel.interactable = false;
        Debug.Log("ogwogogkeokgw Game clicked");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
