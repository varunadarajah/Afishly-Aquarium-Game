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


    public float minX = -.3f;
    public float maxX = .3f;
    public float minY = -.9f;
    public float maxY = -.6f;

    public void buy()
    {
        inactiveCount++;
    }

    public void placeDecor()
    {
        if (inactiveCount > 0) { 
        float xPos = Random.Range(minX, maxX);

        GameObject newDecor = Instantiate(decorPrefab, decorPlace.transform);
        newDecor.transform.position = new Vector3(xPos, newDecor.transform.position.y, newDecor.transform.position.z);

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

    public int getTotalCount()
    {
        return activeCount + inactiveCount;
    }
}
