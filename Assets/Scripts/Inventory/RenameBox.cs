using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RenameBox : MonoBehaviour
{
    public FishView box;
    public TMP_InputField inputField;

    public int maxCharLength = 15;
    // Start is called before the first frame update
    void Start()
    {
        inputField.text = box.fish.fishName;
    }

    public void saveName()
    {
        string newName = inputField.text;

        if(newName.Length <= maxCharLength)
        {
            box.fish.fishName = newName;
            Destroy(gameObject);
        }

        //sorting
        FilterBoxManager filter = box.fm.filter;
        filter.SelectTab(filter.curSelectedTab);
    }
}
