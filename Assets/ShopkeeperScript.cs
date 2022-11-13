using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperScript : MonoBehaviour
{
    public GameObject shopWindow;
    public GameObject DialogueBox;
    public GameObject interactKeyText;

    public bool nearNPC;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("player entered");
            nearNPC = true;
            interactKeyText.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        nearNPC = false;
        interactKeyText.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && nearNPC)
        {
            DialogueBox.SetActive(true);
            
        }

        
    }

    public void DialogueBoxAccept()
    {
        shopWindow.SetActive(true);
        DialogueBox.SetActive(false);
        interactKeyText.SetActive(false);
    }

    public void DeclineOrQuit()
    {
        DialogueBox.SetActive(false);
    }



}
