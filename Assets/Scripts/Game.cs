using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public int pearls = 0;
    public TMP_Text pearlText;

    public List<Fish> fishInventory;
    public int fishInventoryMax = 10;
    public TMP_Text fishText;

    public GameObject CenterRock;
    public GameObject oysterObj;

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
        fishText.text = fishInventory.Count + "/" + fishInventoryMax;
    }

    public void createOyster()
    {
        Instantiate(oysterObj, CenterRock.transform);
    }
}
