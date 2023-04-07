using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Game game;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        purchaseOyster();
    }

    bool purchaseOyster()
    {
        if(game.pearls >= 50)
        {
            game.createOyster();
            game.pearls -= 50;
            //close menu
            return true;
        }

        return false;
    }
}
