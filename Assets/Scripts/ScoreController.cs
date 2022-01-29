
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI keyText;
    private int Keys = 0;
    private void Awake() {
        keyText = GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        RefreshUI();
    }
    public void IncreaseKeys(int increment)
    {
        Keys += increment;
        RefreshUI();

    }
    public void RefreshUI()
    {
       keyText.text ="Keys: "+ Keys; 
    }


}
