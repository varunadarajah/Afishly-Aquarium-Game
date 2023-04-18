using UnityEngine;
using UnityEngine.UI;

public class DropDownLayerScript : MonoBehaviour
{
    public Dropdown dropdown; // Reference to the Dropdown UI element
    public string layerName; // The name of the layer to set for the child elements

    void Start()
    {
        // Set the layer of the child elements
        SetChildLayer(layerName);
    }

    public void SetChildLayer(string layerName)
    {
        // Get the layer ID based on the name
        int layerID = LayerMask.NameToLayer(layerName);

        // Loop through all the child objects of the Dropdown UI element
        for (int i = 0; i < dropdown.transform.childCount; i++)
        {
            Transform child = dropdown.transform.GetChild(i);
            // Set the layer ID of the child object
            child.gameObject.layer = layerID;
        }
    }
}
