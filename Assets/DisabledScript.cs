using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisabledScript : MonoBehaviour
{
    public GameObject exitText;
    private void OnMouseDown()
    {
        StartCoroutine(ToggleInvalidText());
    }
        

    private IEnumerator ToggleInvalidText()
    {
        exitText.SetActive(true);
        yield return new WaitForSeconds(2f);
        exitText.SetActive(false);
    }
}
