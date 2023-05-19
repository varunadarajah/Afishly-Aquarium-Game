using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAxolotlBox : MonoBehaviour
{
    public GameObject buttonToMove;
    public float targetYPositionOpen;
    public float targetYPositionClose;
    public float slideDuration = 1f;
    public GameObject toggleUpArrow;
    public GameObject toggleDownArrow;
    public GameObject expandWindow;

    private bool isMoving = false;

    private void OnMouseDown()
    {
        if (!isMoving)
        {
            if (toggleUpArrow.activeSelf) {
                StartCoroutine(MenuClose(buttonToMove));
            }
            if (toggleDownArrow.activeSelf) {
            StartCoroutine(MenuOpen(buttonToMove));
            }
        }
    }

    private IEnumerator MenuOpen(GameObject button)
    {
        isMoving = true;
        button.SetActive(true);
        targetYPositionOpen = transform.position.y - .57f;
        Vector3 startPosition = button.transform.position;
        Vector3 targetPosition = new Vector3(startPosition.x, targetYPositionOpen, startPosition.z);
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

    private IEnumerator MenuClose(GameObject button)
    {
        isMoving = true;
        button.SetActive(true);
        targetYPositionClose = transform.position.y - 1.42f;
        Vector3 startPosition = button.transform.position;
        Vector3 targetPosition = new Vector3(startPosition.x, targetYPositionClose, startPosition.z);
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
    }
}
