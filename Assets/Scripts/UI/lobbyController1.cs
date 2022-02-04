using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
public class lobbyController1 : MonoBehaviour
{
    public Button startButton;
    private void Awake() {
        startButton.onClick.AddListener(StartScene);
        //Debug.Log("hai");
    }
    void StartScene()
    {
        Debug.Log("hello");
        SceneManager.LoadScene(1);
    }
}
