using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string[] levels;


    private static LevelManager instance;
    public static LevelManager Instance {get {return instance;}}
    private void Awake() {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        } 
    }
    
    private void Start() {
        if(GetLevelStatus(levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(levels[0],LevelStatus.Unlocked);
        }
    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus LevelStatus = (LevelStatus) PlayerPrefs.GetInt(level,0);
        return LevelStatus;
    }
    public void SetLevelStatus(string level,LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level,(int)levelStatus);
    }

    public void MarkLevelCompleted()
    {   
        string currentSceneName =  SceneManager.GetActiveScene().name;
        SetLevelStatus(currentSceneName,LevelStatus.Completed);

        int currentSceneIndex = Array.FindIndex(levels,levels => levels == currentSceneName);
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex<levels.Length)
        {
            SetLevelStatus(levels[nextSceneIndex],LevelStatus.Unlocked);
        }
    }

}
