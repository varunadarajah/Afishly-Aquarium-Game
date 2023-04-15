using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaBox : MonoBehaviour
{
    public string gachaName;
    public int cost;

    public List<Fish> possibleFishes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Fish OpenBox()
    {
        int random = UnityEngine.Random.Range(0, possibleFishes.Count-1);
        return possibleFishes[random];
    }

}
