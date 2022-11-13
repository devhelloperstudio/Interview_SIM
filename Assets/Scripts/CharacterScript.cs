using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterScript : MonoBehaviour
{
    public int cooking;
    public int charisma;
    public int money = 9876;

    public TMP_Text cookingText;
    public TMP_Text charismaText;
    public TMP_Text moneyText;

    

    void Start()
    {
        UpdateStats();
    }


    public void UpdateStats()
    {
        cookingText.text = "Cooking: " + cooking;
        charismaText.text = "Charisma: " + charisma;
        moneyText.text = "Money: " + money;
    }

}
