using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public int pearls = 0;
    public TMP_Text pearlText;

    public GameObject CenterRock;
    public GameObject oysterObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // update currency
        pearlText.text = pearls + "";
    }

    void buyOyster()
    {
        Instantiate(oysterObj, CenterRock.transform);
    }
}
