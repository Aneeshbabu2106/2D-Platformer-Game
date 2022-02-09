using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    PlayerDamage PD;
    private float health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    private void Awake() {
        PD = GetComponent<PlayerDamage>();
    }
    void Update()
    {
        health = PD.health;
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for(int i=0;i<hearts.Length;i++)
        {
            if(i<health)
            {
                hearts[i].sprite = fullHeart;
                hearts[i].enabled=true;
            }else{
                hearts[i].enabled=false;
            }
        }
        
    }
}
