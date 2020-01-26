using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int health;
    public int numOfHearts;

    public List<Image> hearts = new List<Image>();
    public Sprite Heart64;
    public Sprite Nheart;

    public PlayerMovement PM;

    private void Start()
    {
 
        PM = this.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        health = PM.GetIndex();

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Count; i++)
        {

            if (i < health)
            {
                hearts[i].sprite = Heart64;
            }
            else
            {
                hearts[i].sprite = Nheart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

     }
}

