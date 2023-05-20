using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    public GameObject VanillaBox;
    public GameObject TurtleBox;
    public ScrollRect scrollRect;

    void Update()
    {
        // check if the target object is active
        bool isActiveVanilla = VanillaBox.activeSelf;
        bool isActiveTurtle = TurtleBox.activeSelf;

        // disable the ScrollRect if the target object is not active
        if (isActiveVanilla || isActiveTurtle)
        {
            scrollRect.enabled = true;
        }
        else
        {
            scrollRect.enabled = false;
        }
    }
}
