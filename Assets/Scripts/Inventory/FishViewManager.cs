using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishViewManager : MonoBehaviour
{
    public Game game;

    public List<Fish> fishes;
    int ownedCount = 0;
    int activeCount = 0;

    public TMP_Text breedText;
    public TMP_Text ownedText;
    public TMP_Text activeText;

    public GameObject fishBoxesTab; // where to instatiate objects
    public GameObject fishViewObj; // view prefab to be instantiated

    public List<GameObject> boxes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ownedText.text = ownedCount + "";
        activeText.text = activeCount + "";
    }

    public void SetFish(string breedName)
    {
        Reset();

        foreach(Fish f in game.fishInventory) // adds matching fish to a list
        {
            if(f.fishBreed.Equals(breedName))
            {
                fishes.Add(f);
                ownedCount++;

                // adds view boxes for each fish in list
                GameObject newBox = Instantiate(fishViewObj, fishBoxesTab.transform);
                newBox.GetComponent<FishView>().fish = f;
                boxes.Add(newBox);
            }
        }

        breedText.text = breedName;
    }

    void Reset()
    {
        fishes.Clear();
        ownedCount = 0;
        activeCount = 0;

        foreach(GameObject box in boxes)
        {
            Destroy(box);
        }
        boxes.Clear();
    }
}
