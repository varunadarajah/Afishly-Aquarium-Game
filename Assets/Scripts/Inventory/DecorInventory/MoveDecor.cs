using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDecor : MonoBehaviour
{
    public GameObject EditModeButtons;
    public GameObject MoveDecorScreen;
    public Game game;
    public GameObject parentObject;

    private Renderer decorRenderer;
    private Color originalColor;

    private void Start()
    {
        decorRenderer = GetComponent<Renderer>();
        originalColor = decorRenderer.material.color;
    }

    private void Update()
    {
        bool anyChildSelected = false;

        PlantRock[] allPlantRocks = parentObject.GetComponentsInChildren<PlantRock>(true);

        foreach (PlantRock plantRock in allPlantRocks)
        {
            if (plantRock.selected)
            {
                anyChildSelected = true;
                break;
            }
        }

        if (anyChildSelected)
        {
            SetOpacity(1f);
        }
        else
        {
            SetOpacity(0f);
        }
    }

    private void SetOpacity(float alpha)
    {
        Color color = decorRenderer.material.color;
        color.a = alpha;
        decorRenderer.material.color = color;
    }

    private void OnMouseDown()
    {
        // Get child objects of the parent object
        Transform[] childObjects = parentObject.GetComponentsInChildren<Transform>();

        foreach (Transform childObject in childObjects)
        {
            // Check if the child object has a PlantRock component
            PlantRock plantRock = childObject.GetComponent<PlantRock>();
            if (plantRock != null && plantRock.selected)
            {
                plantRock.canMove = true;
                EditModeButtons.SetActive(false);
                MoveDecorScreen.SetActive(true);
                PlantRock[] plantRocks = FindObjectsOfType<PlantRock>();
                foreach (PlantRock otherPlantRock in plantRocks)
                {
                    if (otherPlantRock.gameObject != gameObject && !otherPlantRock.selected)
                    {
                        Collider2D[] colliders = otherPlantRock.GetComponents<Collider2D>();
                        foreach (Collider2D collider in colliders)
                        {
                            collider.enabled = false;
                        }
                    }
                }
            }
        }
    }
}
