using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellFishButton : MonoBehaviour
{
    public FishView box;
    public GameObject fishPage;
    public GameObject sellBox; // prefab

    // Start is called before the first frame update
    void Start()
    {
        fishPage = GameObject.Find("FishViewPage");
    }

    public void OpenSellFishBox()
    {
        GameObject newSellBox = Instantiate(sellBox, fishPage.transform);
        newSellBox.GetComponent<SellBox>().fishNameText.text = box.fish.fishName;
        newSellBox.GetComponent<SellBox>().priceText.text = "For " + box.fish.sellPrice + " <sprite name=\"Pearl\">";
        newSellBox.GetComponent<SellBox>().box = box;
    }
}
