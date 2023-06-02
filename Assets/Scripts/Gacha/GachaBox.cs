using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaBox : MonoBehaviour
{
    public string gachaName;
    public int cost = 50;

    public int boxLevel = 1;

    public List<Fish> possibleFishes;
    public List<int> fishRarity;

    public Animator boxAnimation;

    // Start is called before the first frame update
    void Start()
    {
        boxAnimation = gameObject.GetComponent<Animator>();
        // adds index of fish to rarity list depending on specified rarity
        foreach (Fish f in possibleFishes)
        {
            for (int i = 0; i < f.rarity; i++)
            {
                fishRarity.Add(possibleFishes.IndexOf(f));
            }
        }
    }

    public Fish OpenBox()
    {
        levelUp();
        boxAnimation.SetTrigger("Active");
        // randomly chooses an index of a fish from fishRarity list and returns cooresponding list
        int random = UnityEngine.Random.Range(0, fishRarity.Count - 1);
        return possibleFishes[fishRarity[random]];
    }

    public void levelUp()
    {
        if(boxLevel < 5)
        {
            cost += 50;
        } 
        else if(boxLevel == 5)
        {
            cost = 500;
        }
        else if(boxLevel < 11)
        {
            cost += 100;
        } 
        else if(boxLevel < 16)
        {
            cost += 200;
        }
        else if (boxLevel < 26)
        {
            cost += 250;
        }
        else if (boxLevel < 35)
        {
            cost += 500;
        }
        else if (boxLevel < 41)
        {
            cost += 1000;
        }
        else if (boxLevel < 45)
        {
            cost += 2500;
        }
        else if (boxLevel < 50)
        {
            cost += 5000;
        } 
        else if (boxLevel == 50)
        {
            cost = 100000;
        }

        if(boxLevel < 51)
        {
            boxLevel++;
        }
    }

}
