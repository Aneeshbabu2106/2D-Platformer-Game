using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
public class lobbyController1 : MonoBehaviour
{
    public Button startButton;
    public GameObject levelSelection;
    public Button optionButton;
    public Button exitButton;

    private void Awake() {
        startButton.onClick.AddListener(StartScene);
        optionButton.onClick.AddListener(OptionScene);
        exitButton.onClick.AddListener(ExitGame);
    }
    void StartScene()
    {
        levelSelection.SetActive(true);
    }
    void OptionScene()
    {
        Debug.Log("load options");
    }
    void ExitGame()
    {
       Debug.Log("exit game");
    }
}
