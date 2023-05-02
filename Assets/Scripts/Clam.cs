using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clam : MonoBehaviour
{
    public Game game;
    public int pearlPerTap = 100;
    Animator clamAnimation;
    // Start is called before the first frame update
    void Start()
    {
        clamAnimation = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        game.pearls += pearlPerTap;
        clamAnimation.SetTrigger("Active");

    }
}
