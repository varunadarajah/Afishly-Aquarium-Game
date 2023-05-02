using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransitionScript : MonoBehaviour
{
    public GameObject transitionScreen;
    private Material screenMaterial;
    private Color screenColor;
    private bool inputEnabled = false;

    public void OnMouseDown()
    {
        if (inputEnabled)
        {
            StartCoroutine(HideTransitionScreen());
        }
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0f);
        inputEnabled = true;
    }

    private IEnumerator HideTransitionScreen()
    {
        Renderer screenRenderer = transitionScreen.GetComponent<Renderer>();
        screenMaterial = screenRenderer.material;
        screenColor = screenMaterial.color;
        screenColor.a = 0f;
        screenMaterial.color = screenColor;
        yield return StartCoroutine(Start());
        transitionScreen.SetActive(false);
    }
}

