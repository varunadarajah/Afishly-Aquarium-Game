using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFishView : MonoBehaviour
{
    public GameObject FishViewPage;
    public GameObject BoxesPage;

    private void OnMouseDown()
    {
        FishViewPage.SetActive(false);
        BoxesPage.SetActive(true);

    }
}
