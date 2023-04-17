using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public int pearls = 0;
    public TMP_Text pearlText;

    public List<Fish> fishInventory;

    public List<Fish> activeFish;
    public int activeFishMax = 10;
    public TMP_Text fishText;

    // stats variables
    public int totalPearls = 0;
    public int totalClicks = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // update currency
        pearlText.text = pearls + "";

        // update fish count
        fishText.text = activeFish.Count + "/" + activeFishMax;
    }
}
