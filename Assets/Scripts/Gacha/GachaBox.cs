using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaBox : MonoBehaviour
{
    public string gachaName;
    public int cost;

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
            for(int i = 0; i < f.rarity; i++)
            {
                fishRarity.Add(possibleFishes.IndexOf(f));
            }
        }
    }

    public Fish OpenBox()
    {
        boxAnimation.SetTrigger("Active");
        // randomly chooses an index of a fish from fishRarity list and returns cooresponding list
        int random = UnityEngine.Random.Range(0, fishRarity.Count-1);
        return possibleFishes[fishRarity[random]];
    }

}
