using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DecorInventory : MonoBehaviour
{
    public List<DecorManager> plants;
    public List<DecorManager> rocks;

    public List<TMP_Text> plantsTotalOwnedText;
    public List<TMP_Text> rocksTotalOwnedText;

    private void Update()
    {
        // plants
        for(int i = 0; i < plants.Count; i++)
        {
            plantsTotalOwnedText[i].text = "Total Owned: " + plants[i].getTotalCount();
        }

        // rocks
        for (int i = 0; i < rocks.Count; i++)
        {
            rocksTotalOwnedText[i].text = "Total Owned: " + rocks[i].getTotalCount();
        }
    }
}
