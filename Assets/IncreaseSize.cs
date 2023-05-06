using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSize : MonoBehaviour
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
                currentScale += new Vector3(1f, 1f, 1f);
                if (currentScale.x <= 50 && currentScale.y <= 50 && currentScale.z <= 50)
                {
                    plantRock.transform.localScale = currentScale;
                }
            }
        }
    }
}
