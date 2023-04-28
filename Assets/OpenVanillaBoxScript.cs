using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenVanillaBoxScript : MonoBehaviour
{
    public Animator VanillaBoxAnimation;

    void Start()
    {
        VanillaBoxAnimation = GameObject.Find("VanillaBox").GetComponent<Animator>(); // Replace "NameOfOtherObject" with the name of the other object in the scene
    }

    void OnMouseDown()
    {
        VanillaBoxAnimation.SetTrigger("Active");
    }
}
