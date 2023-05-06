using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseSize : MonoBehaviour
{
    public GameObject parentObject;

    private void OnMouseDown()
    {
        PlantRock[] plantRocks = parentObject.GetComponentsInChildren<PlantRock>();
        foreach (PlantRock plantRock in plantRocks)
        {
            if (plantRock.selected == true)
            {
                Vector3 currentScale = plantRock.transform.localScale;
                currentScale -= new Vector3(1f, 1f, 1f);
                if (currentScale.x >= 15 && currentScale.y >= 15 && currentScale.z >= 15)
                {
                    plantRock.transform.localScale = currentScale;
                }
            }
        }
    }
}
