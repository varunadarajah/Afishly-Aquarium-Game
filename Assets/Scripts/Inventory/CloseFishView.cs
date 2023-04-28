using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFishView : MonoBehaviour
{
    public FishViewManager fm;
    public GameObject FishViewPage;
    public GameObject BoxesPage;

    private void OnMouseDown()
    {
        fm.filter.setDefaultTab();
        FishViewPage.SetActive(false);
        BoxesPage.SetActive(true);

    }
}
