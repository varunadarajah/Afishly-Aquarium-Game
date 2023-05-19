using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFishView : MonoBehaviour
{
    public FishViewManager fm;
    public GameObject FishViewPage;
    public GameObject BoxesPage;

    public string FishBreedName;

    private void OnMouseDown()
    {
        fm.SetFish(FishBreedName);
        FishViewPage.SetActive(true);
        BoxesPage.SetActive(false);
    }
}
