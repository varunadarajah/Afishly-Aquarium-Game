using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAxolotlBox : MonoBehaviour
{
    public GameObject buttonToMove;
    public float targetYPosition;
    public float slideDuration = 1f;
    public GameObject toggleUpArrow;
    public GameObject toggleDownArrow;
    public GameObject collapseWindow;

    private bool isMoving = false;

    private void OnMouseDown()
    {
        if (!isMoving)
        {
            StartCoroutine(MenuClose(buttonToMove));                  
        }
    }

    private IEnumerator MenuClose(GameObject button)
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
        if (collapseWindow != null)
        {
            collapseWindow.SetActive(!collapseWindow.activeSelf); 
        }
    }
    }

