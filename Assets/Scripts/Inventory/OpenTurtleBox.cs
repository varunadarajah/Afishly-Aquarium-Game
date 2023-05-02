using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTurtleBox : MonoBehaviour
{
    public GameObject buttonToMove;
    public GameObject toggleUpArrow;
    public GameObject toggleDownArrow;
    public GameObject toggleVanillaUpArrow;
    public GameObject toggleVanillaDownArrow;
    public GameObject closeVanillaBox;
    public GameObject expandWindow;
    public float slideDuration = 1f;
    public float targetYPosition;


    private bool isMoving = false;

    private void OnMouseDown()
    {
        if (!isMoving)
        {
            StartCoroutine(MenuOpen(buttonToMove));
        }
    }

    private IEnumerator MenuOpen(GameObject button)
    {
        isMoving = true;
        button.SetActive(true);

        Vector3 startPosition = button.transform.position;
        Vector3 targetPosition = new Vector3(startPosition.x, targetYPosition, startPosition.z);
        float elapsedTime = 0f;

        while (elapsedTime < slideDuration)
        {
            float t = elapsedTime / slideDuration;
            button.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        button.transform.position = targetPosition;
        isMoving = false;
        toggleArrow();
    }


    void toggleArrow()
    {
        if (toggleUpArrow != null)
        {
            toggleUpArrow.SetActive(!toggleUpArrow.activeSelf);
        }
        if (toggleDownArrow != null)
        {
            toggleDownArrow.SetActive(!toggleDownArrow.activeSelf); 
        }
        if (expandWindow != null)
        {
            expandWindow.SetActive(!expandWindow.activeSelf);
        }
        if (closeVanillaBox != null)
        {
            closeVanillaBox.SetActive(false);
        }
        if (toggleVanillaUpArrow != null)
        {
            toggleVanillaUpArrow.SetActive(true);
        }
        if (toggleVanillaDownArrow != null)
        {
            toggleVanillaDownArrow.SetActive(false);
        }
    }
}
