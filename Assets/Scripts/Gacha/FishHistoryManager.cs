using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishHistoryManager : MonoBehaviour
{
    public Game game;

    public List<GameObject> boxes;
    public GameObject RollHistoryBox; // prefab
    public GameObject boxesObj; // gameobject to where boxes are instantiated

    public ScrollRect scroll; // to reset scroll position

    public void display()
    {
        Clear();
        addHistoryBoxes();
        scroll.verticalNormalizedPosition = 0f;
    }

    public void addHistoryBoxes()
    {
        foreach (FishHistoryRecord f in game.fishHistory)
        {
            GameObject newBox = Instantiate(RollHistoryBox, boxesObj.transform);
            newBox.GetComponent<FishHistoryBox>().record = f;
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
