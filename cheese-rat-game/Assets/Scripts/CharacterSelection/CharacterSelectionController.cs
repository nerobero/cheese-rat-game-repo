using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionController : MonoBehaviour
{
    public void SelectRat()
    {
        PlayerPrefs.SetString("SelectedCharacter", "Rat");
        LoadGameScene();
    }

    public void SelectSpider()
    {
        PlayerPrefs.SetString("SelectedCharacter", "Spider");
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}