using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DecorView : MonoBehaviour
{
    public DecorManager decor;
    public TMP_Text inactiveText;
    public TMP_Text activeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateCountText();
    }

    void updateCountText()
    {
        inactiveText.text = decor.inactiveCount + "";
        activeText.text = decor.activeCount + "";
    }
}
