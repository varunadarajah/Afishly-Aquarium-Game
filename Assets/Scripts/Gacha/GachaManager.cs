using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GachaManager : MonoBehaviour
{
    public Game game;

    public GameObject GachaBoxes;
    public List<GachaBox> boxes;

    public GachaBox selectedBox;
    public TMP_Text selectedText;
    public TMP_Text costText;

    // Start is called before the first frame update
    void Start()
    {
        // auto adds all gacha boxes within the GachaBoxes object
        Transform[] children = GachaBoxes.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            boxes.Add(child.gameObject.GetComponent<GachaBox>());
        }
        boxes.RemoveAt(0); // removes empty parent object from list
        selectedBox = boxes[0];
    }

    // Update is called once per frame
    void Update()
    {
        selectedText.text = selectedBox.gachaName;
        costText.text = selectedBox.cost + "";
    }

    public void ScrollLeft()
    {
        if (boxes.IndexOf(selectedBox) == 0)
        {
            selectedBox = boxes[boxes.Count - 1];
        }
        else
        {            
            selectedBox = boxes[(boxes.IndexOf(selectedBox) - 1)];
        }
    }

    public void ScrollRight()
    {
        if(boxes.IndexOf(selectedBox) == boxes.Count-1)
        {
            selectedBox = boxes[0];
        }
        else
        {
            selectedBox = boxes[(boxes.IndexOf(selectedBox) + 1)];
        }
    }

    public void buyBox()
    {
        if(game.pearls >= selectedBox.cost)
        {
            game.pearls -= selectedBox.cost;
            game.fishInventory.Add(selectedBox.OpenBox());
        }
    }
}
