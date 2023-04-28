using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFilterBox : MonoBehaviour
{
    public GameObject filterBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        filterBox.SetActive(false);
    }
}
