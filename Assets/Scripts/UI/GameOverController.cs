using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverController : MonoBehaviour
{ 
    public Button restartButton;
    public Button toLobbyButton;
    private void Awake() {
        restartButton.onClick.AddListener(RefreshScene);
        toLobbyButton.onClick.AddListener(firstScene);
        //Debug.Log("hai");
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    void RefreshScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void firstScene()
    {
        SceneManager.LoadScene(0);
    }
}
