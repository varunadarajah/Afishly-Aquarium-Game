using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject EditModeButtons;
    public GameObject MoveDecorScreen;
    public GameObject InvalidText;

    private Collider2D confirmCollider;
    private bool greenOutlineActive = false;


    private void Start() {
        confirmCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        greenOutlineActive = false; // Reset to false at the start of each frame
        Transform[] childObjects = parentObject.GetComponentsInChildren<Transform>();
        foreach (Transform childObject in childObjects)
        {
            PlantRock plantRock = childObject.GetComponent<PlantRock>();
            if (plantRock != null) 
            {
                if (plantRock.GreenOutline.activeSelf) {
                    greenOutlineActive = true;
                }
            }
        }

        if (greenOutlineActive == true) {
            confirmCollider.enabled = true;
            SetObjectOpacity(gameObject, 1f);
        } else if (greenOutlineActive == false){
            confirmCollider.enabled = false;
            SetObjectOpacity(gameObject, 0.25f); 
        }     
    }
    

    private void OnMouseDown()
    {
        Transform[] childObjects = parentObject.GetComponentsInChildren<Transform>();
        foreach (Transform childObject in childObjects)
        {
            PlantRock plantRock = childObject.GetComponent<PlantRock>();
            if (plantRock != null) 
            {
                plantRock.canMove = false;
                plantRock.selected = false;
                plantRock.GreenOutline.SetActive(false);
                plantRock.RedOutline.SetActive(false);
            }
        }

        for (int i = 0; i < parentObject.transform.childCount; i++)
        {
            Renderer childRenderer = parentObject.transform.GetChild(i).GetComponent<Renderer>();
            if (childRenderer != null)
            {
                Color childColor = childRenderer.material.color;
                childColor.a = 1f;
                childRenderer.material.color = childColor;
            }
        }
        
        PlantRock[] plantRocks = FindObjectsOfType<PlantRock>();
        foreach (PlantRock plantRock in plantRocks)
        {
            if (plantRock.gameObject != gameObject)
            {
                Collider2D[] colliders = plantRock.GetComponents<Collider2D>();
                foreach (Collider2D collider in colliders)
                {
                    collider.enabled = true;
                }
            }
        }
        greenOutlineActive = false;
        InvalidText.SetActive(false);
        EditModeButtons.SetActive(true);
        MoveDecorScreen.SetActive(false);
    }

    private void SetObjectOpacity(GameObject obj, float opacity)
    {
    Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
    foreach (Renderer renderer in renderers)
    {
        Color color = renderer.material.color;
        color.a = opacity;
        renderer.material.color = color;
    }
    }
}
