using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class LoadLevelScene : MonoBehaviour
{
    private Button Button;
    public string levelName;
 
    private void Awake() {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(LoadLevel);
    }
    void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
