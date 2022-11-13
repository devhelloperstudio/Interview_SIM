using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro ;

public class ClothesScript : MonoBehaviour
{
    public GameObject clothesItem;
    public GameObject error;
    public Image ownedOutline;

    public GameObject buyButton;
    public GameObject sellButton;

    public Color32 affordableColor;
    public Color32 ownedColor;
    public Color32 unafoordableColor;

    public TMP_Text errorText;
    public TMP_Text statsTextCharisma;
    public TMP_Text statsTextCooking;

    public Sprite sprite;
    
    public CharacterClothesManager characterClothes;
    public CharacterScript characterScript;


    public int charisma;
    public int cooking;
    public int cost;
    public bool equipped;

    bool pressed;
    private float timePressed;

    public bool owned = true;

    public enum ClothesType // choose item type
    {
        Head,
        Torso,
        Pants,
        Feet,
    }
    public ClothesType clothesType;


    private void Start()
    {
        CheckColorType();
        statsTextCharisma.text = "Charisma: " + charisma;
        statsTextCooking.text = "Cooking: " + cooking;
    }

    public void EquipClothes()
    {
        if (owned)
        {
            
            switch (clothesType) // check what type of clothing is this item
            {
                case (ClothesType.Head):
                    if (characterClothes.playerHead.GetComponent<ClothesScript>() != null)
                    {
                        characterClothes.oldAddedCharisma += characterClothes.playerHead.GetComponent<ClothesScript>().charisma;
                        characterClothes.oldAddedCharisma += characterClothes.playerHead.GetComponent<ClothesScript>().cooking;
                    }
                    characterClothes.playerHead = clothesItem;
                    characterClothes.UpdateHead();
                    characterClothes.UpdateStats(charisma, cooking);
                    break;

                case (ClothesType.Torso):
                    if (characterClothes.playerTorso.GetComponent<ClothesScript>() != null)
                    {
                        characterClothes.oldAddedCharisma += characterClothes.playerTorso.GetComponent<ClothesScript>().charisma;
                        characterClothes.oldAddedCharisma += characterClothes.playerTorso.GetComponent<ClothesScript>().cooking;
                    }
                    characterClothes.playerTorso = clothesItem;
                    characterClothes.UpdateTorso();
                    characterClothes.UpdateStats(charisma, cooking);
                    break;
                case (ClothesType.Pants):
                    if (characterClothes.playerPants.GetComponent<ClothesScript>() != null)
                    {
                        characterClothes.oldAddedCharisma += characterClothes.playerPants.GetComponent<ClothesScript>().charisma;
                        characterClothes.oldAddedCharisma += characterClothes.playerPants.GetComponent<ClothesScript>().cooking;
                    }
                    characterClothes.playerPants = clothesItem;
                    characterClothes.UpdatePants();
                    characterClothes.UpdateStats(charisma, cooking);
                    break;
                case (ClothesType.Feet):
                    if (characterClothes.playerFeet.GetComponent<ClothesScript>() != null)
                    {
                        characterClothes.oldAddedCharisma += characterClothes.playerFeet.GetComponent<ClothesScript>().charisma;
                        characterClothes.oldAddedCharisma += characterClothes.playerFeet.GetComponent<ClothesScript>().cooking;
                    }
                    characterClothes.playerFeet = clothesItem;
                    characterClothes.UpdateFeet();
                    characterClothes.UpdateStats(charisma, cooking);
                    break;
            }
            characterScript.UpdateStats();
            ChangeButtonType();
            CheckColorType();
            
        }
        else
        {
            if(characterScript.money >= cost)
            {
                characterScript.money -= cost;
                owned = true;
                characterClothes.ownedClothes.Add(gameObject);
                EquipClothes();
            }
            else
            {
                error.SetActive(true);
                errorText.text = "You can't afford that!";
            }
            CheckColorType();
        }
        // de adaugat unequip - last
        // de adaugat dialog menu - done
        // de adaugat shop - done
        // de adaugat npc - done
        // de adaugat butoane - done
        // movement - done
    }

    public void SellClothes() // this will not unequip the item. player will receive the money, keep the sprite BUT will have the item stats deleted.
    {
        if (owned )
        {
            owned = false;
            characterScript.money += cost;
            characterClothes.oldAddedCharisma += charisma;
            characterClothes.oldAddedCooking += cooking;
            characterClothes.UpdateStats(0, 0);
            characterScript.UpdateStats();
            CheckColorType();
            ChangeButtonType();
        }
    }

    private void CheckColorType()
    {
        if (cost > characterScript.money && !owned)
        {
            ownedOutline.color = unafoordableColor;
        }
        else if (cost <= characterScript.money && !owned)
        {
            ownedOutline.color = affordableColor;
        }
        else
        {
            ownedOutline.color = ownedColor;
        }
    }

    private void ChangeButtonType()
    {
        if (buyButton.activeSelf)
        {
            sellButton.SetActive(true);
            buyButton.SetActive(false);
        }
        else
        {
            sellButton.SetActive(false);
            buyButton.SetActive(true);
        }
    }
}
