using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mussel : MonoBehaviour
{
    public Game game;
    public UnlockMusselScript curr;

    // Start is called before the first frame update
    void Start()
    {
        if (curr.currentLevel == 1)
        {
            StartCoroutine(IncreasePearls());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IncreasePearls()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second

            int pearlsPerSecond = 5;

            // Increase pearls per second to 6 at level 2
            if (curr.currentLevel == 2)
            {
                pearlsPerSecond = 6;
            }

            if (curr.currentLevel == 3)
            {
                pearlsPerSecond = 8;
            }

            // Increase pearls in the other object by pearlsPerSecond
            game.pearls += pearlsPerSecond;
        }
    }
}
