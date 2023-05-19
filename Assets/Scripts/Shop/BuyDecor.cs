using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyDecor : MonoBehaviour
{
    public Game game;
    public DecorManager decor;
    public GameObject GrayLayer;

    public TMP_Text buyText;
    public Button button;
    private static BuyDecor activeInstance; // Static variable to store the active instance
    private int clickCount;
    public int cost;
    string spriteAsset = "<sprite name=\"Pearl\">";

    void Update()
    {
        if (clickCount == 0) 
        {
           buyText.text = "Purchase\n " + cost + " " + spriteAsset;
        }
        button.interactable = game.pearls >= cost;
        GrayLayer.SetActive(!button.interactable);
    }

     private void OnDisable()
    {
        clickCount = 0;
        if (activeInstance == this) // Reset the active instance if it gets disabled
        {
            activeInstance = null;
        }
    }

    private void OnMouseDown()
    {
        if (game.pearls >= cost)
        {
            if (button.interactable == true)
            {
                if (activeInstance != null && activeInstance != this) // Check if there is an active instance and it's not the current one
                {
                    activeInstance.ResetToBuyText(); // Reset the text of the previous active instance
                }
                
                clickCount++;
                if (clickCount == 1)
                {
                    buyText.text = "Confirm";
                    activeInstance = this; // Set this instance as the active instance
                }
                else if (clickCount == 2)
                {
                    game.pearls -= cost;
                    decor.buy();
                    clickCount = 0;
                    activeInstance = null; // Reset the active instance
                }
            }
        }
    }

    private void ResetToBuyText()
    {
        clickCount = 0;
        buyText.text = "Purchase\n " + cost + " " + spriteAsset;
    }
}
