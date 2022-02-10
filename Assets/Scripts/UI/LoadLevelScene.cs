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
        Button.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("can't  load");
                break;
            case LevelStatus.Unlocked:
                LoadLevel();
                break;
            case LevelStatus.Completed:
                LoadLevel();
                break;

        }
    }
    void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
