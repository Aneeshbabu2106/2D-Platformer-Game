using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{    
    private int nextScene;
    void Start()
    {
        nextScene=SceneManager.GetActiveScene().buildIndex + 1; 
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene(nextScene);                       //loading next scene
    }
}
