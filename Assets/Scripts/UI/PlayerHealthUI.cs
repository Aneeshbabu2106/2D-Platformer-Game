using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    Player_controller PC;
    private float health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    private void Awake() {
        PC = GetComponent<Player_controller>();
    }
    void Update()
    {
        health = PC.health;
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
