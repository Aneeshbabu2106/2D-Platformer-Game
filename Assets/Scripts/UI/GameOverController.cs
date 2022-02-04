using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverController : MonoBehaviour
{ 
    public Button restartButton;
    private void Awake() {
        restartButton.onClick.AddListener(RefreshScene);
        //Debug.Log("hai");
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    void RefreshScene()
    {
        //Debug.Log("hello");
        SceneManager.LoadScene(1);
    }
}
