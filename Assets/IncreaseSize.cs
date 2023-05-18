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
                Vector3 currentScale = plantRock.transform.parent.localScale;
                currentScale += new Vector3(.1f, .1f, .1f);
                if (currentScale.x <= 2 && currentScale.y <= 2 && currentScale.z <= 2)
                {
                    plantRock.transform.parent.localScale = currentScale;
                }
            }
        }
    }
}
