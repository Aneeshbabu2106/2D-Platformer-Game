using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{    
    private int nextScene;
    public int totalKeys;
    public ScoreController scoreController;
    public PopUpMessage popUpMessage;
    void Start()
    {
        nextScene=SceneManager.GetActiveScene().buildIndex + 1; 
        
    }
    private void OnTriggerEnter2D(Collider2D other) {

        if(scoreController.Keys == totalKeys){
            SceneManager.LoadScene(nextScene);           //loading next scene
            LevelManager.Instance.MarkLevelCompleted();
        }
        else{
            popUpMessage.enableMessage(); 
        }                                             
    }

    private void OnTriggerExit2D(Collider2D other) {
            popUpMessage.disableMesage();                                     
    }


}
