using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePageCloseForMove : MonoBehaviour
{
    public GameObject pageClose;
     
    private void OnMouseDown()
    {
        pageClose.SetActive(false);
    }
}
