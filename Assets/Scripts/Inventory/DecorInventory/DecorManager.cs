using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorManager : MonoBehaviour
{
    public Game game;

    public string decorName;
    public GameObject decorPrefab;

    public GameObject decorPlace; // where to place decor in hierarchy

    public int inactiveCount = 0;
    public int activeCount = 0;

    public void buy()
    {
        inactiveCount++;
    }

    public void placeDecor()
    {
        if(inactiveCount > 0)
        {
            GameObject newDecor = Instantiate(decorPrefab, decorPlace.transform);
            game.activeDecor.Add(newDecor);

            inactiveCount--;
            activeCount++;
        }
    }

    public void storeDecor()
    {
        activeCount--;
        inactiveCount++;
    }
}
