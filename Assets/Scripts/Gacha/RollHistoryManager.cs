using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollHistoryManager : MonoBehaviour
{
    public GachaManager gm;

    public List<GameObject> boxes;
    public GameObject RollHistoryBox; // prefab
    public GameObject boxesObj; // gameobject to where boxes are instantiated

    public void display()
    {
        Clear();
        addHistoryBoxes();
    }

    public void addHistoryBoxes()
    {
        foreach (FishHistoryRecord f in gm.fishHistory)
        {
            GameObject newBox = Instantiate(RollHistoryBox, boxesObj.transform);
            newBox.GetComponent<RollHistoryBox>().record = f;
            boxes.Add(newBox);
        }
    }

    void Clear()
    {
        foreach (GameObject box in boxes)
        {
            Destroy(box);
        }
        boxes.Clear();
    }
}
