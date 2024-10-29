using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ratPrefab; // Assign your Rat prefab in the Inspector
    public GameObject spiderPrefab; // Assign your Spider prefab in the Inspector
    void Start()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");
        GameObject character = null;

        switch (selectedCharacter)
        {
            case "Rat":
                character = Instantiate(ratPrefab, Vector3.zero, Quaternion.identity); // Replace Vector3.zero with your desired spawn position
                break;
            case "Spider":
                character = Instantiate(spiderPrefab, Vector3.zero, Quaternion.identity); // Replace Vector3.zero with your desired spawn position
                break;
            default:
                Debug.LogError("No character selected");
                break;
        }
    }
}