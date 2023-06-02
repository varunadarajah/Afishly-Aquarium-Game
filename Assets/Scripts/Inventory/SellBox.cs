using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SellBox : MonoBehaviour
{
    public FishView box;
    public TMP_Text fishNameText;
    public TMP_Text priceText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void noPress()
    {
        box.fm.buttonSFX.Play();
        Destroy(gameObject);
    }


    public void yesPress()
    {
        box.Sell();
        Destroy(gameObject);
    }
}
