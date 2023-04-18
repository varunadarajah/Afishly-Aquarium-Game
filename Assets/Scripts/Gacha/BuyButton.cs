using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public GachaManager gm;
    void OnMouseDown()
    {
        gm.buyBox();
    }
}
