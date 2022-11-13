using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClothesManager : MonoBehaviour
{
    public GameObject playerHead;
    public GameObject playerTorso; 
    public GameObject playerPants;
    public GameObject playerFeet;

    public List<GameObject> ownedClothes;


    public SpriteRenderer playerHeadSprite;
    public SpriteRenderer playerTorsoSprite;
    public SpriteRenderer playerPantsSprite;
    public SpriteRenderer playerFeetSprite;

    public CharacterScript characterScript;

    public int addedCooking;
    public int addedCharisma;
    public int oldAddedCooking;
    public int oldAddedCharisma;
    private void Start()
    {

    }
    #region UpdateClothes
    public void UpdateHead()
    {
        Debug.Log("head updated");
            playerHeadSprite.sprite = playerHead.GetComponent<SpriteRenderer>().sprite;
        
    }
    public void UpdateTorso()
    {

            playerTorsoSprite.sprite = playerTorso.GetComponent<SpriteRenderer>().sprite;

    }
    public void UpdatePants()
    {

            playerPantsSprite.sprite = playerPants.GetComponent<SpriteRenderer>().sprite;

    }
    public void UpdateFeet()
    {

            playerFeetSprite.sprite = playerFeet.GetComponent<SpriteRenderer>().sprite;

    }
    #endregion

    public void UpdateStats(int charisma, int cooking)
    {
        characterScript.charisma -= oldAddedCharisma;
        characterScript.cooking -= oldAddedCooking;
        oldAddedCharisma = 0;
        oldAddedCooking = 0;
        characterScript.charisma += charisma;
        characterScript.cooking += cooking;
        characterScript.UpdateStats();
    }



}
