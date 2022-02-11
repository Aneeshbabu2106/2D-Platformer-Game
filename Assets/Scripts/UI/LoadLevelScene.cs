using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class LoadLevelScene : MonoBehaviour
{
    private Button button;
    public string levelName;
    private Image levelImage;
    public Color highlightColor;
    ColorBlock colorBlock; 

    private void Awake() {
        button = GetComponent<Button>();
        levelImage = GetComponent<Image>();    
        button.onClick.AddListener(OnClick);
        
    }
    private void Start() {
        colorBlock = button.colors;
        GetColor();
        
    }

    private void GetColor()
    {

        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("can't  load");
                break;

            case LevelStatus.Unlocked:
                levelImage.color = new Color(levelImage.color.r, levelImage.color.g, levelImage.color.b, 1f);
                colorBlock.highlightedColor = highlightColor;
                break;

            case LevelStatus.Completed:
                levelImage.color = new Color(levelImage.color.r, levelImage.color.g, levelImage.color.b, 1f);
                colorBlock.highlightedColor = highlightColor;
                break;

        }
        button.colors = colorBlock;
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
