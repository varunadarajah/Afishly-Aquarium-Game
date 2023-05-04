using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyDecor : MonoBehaviour
{
    public Game game;

    public DecorManager decor;
    public int cost;

    private void OnMouseDown()
    {
        if(game.pearls >= cost)
        {
            game.pearls -= cost;
            decor.buy();
        }
    }
}
