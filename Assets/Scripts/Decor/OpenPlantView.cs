using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPlantView : MonoBehaviour
{
    public GameObject PlantViewPage;
    public GameObject PlantBox;

    private void OnMouseDown()
    {
        PlantViewPage.SetActive(true);
        PlantBox.SetActive(false);
    }
}
