using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenameFishButton : MonoBehaviour
{
    public FishView box;
    public GameObject fishPage;
    public GameObject renameBox; // prefab

    // Start is called before the first frame update
    void Start()
    {
        fishPage = GameObject.Find("FishViewPage");
    }

    public void openRenameBox()
    {
        GameObject newRenameBox = Instantiate(renameBox, fishPage.transform);
        newRenameBox.GetComponent<RenameBox>().box = box;
    }
}
