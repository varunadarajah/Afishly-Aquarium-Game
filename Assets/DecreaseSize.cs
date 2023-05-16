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
                Vector3 currentScale = plantRock.transform.parent.localScale;
                currentScale -= new Vector3(.1f, .1f, .1f);
                if (currentScale.x >= .5 && currentScale.y >= .5 && currentScale.z >= .5)
                {
                    plantRock.transform.parent.localScale = currentScale;
                }
            }
        }
    }
}
