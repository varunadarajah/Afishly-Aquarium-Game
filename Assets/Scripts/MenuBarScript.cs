using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBarScript : MonoBehaviour
{
    public List<GameObject> menuButtons;

    public float targetYPosition = -0.76f;
    public float slideDuration = 1f;

    private bool isMoving = false;
    private bool isOpen = false;

    private void OnMouseDown()
    {
        if (!isMoving)
        {
            if (isOpen == false)
            {
                foreach (GameObject button in menuButtons)
                {
                    StartCoroutine(MenuOpen(button));
                    targetYPosition += 0.14f;
                }
                isOpen = true;
                targetYPosition = -0.76f;
            } 
            else
            {
                foreach (GameObject button in menuButtons)
                {
                    StartCoroutine(MenuClose(button));                    
                }
                isOpen = false;
            }
            
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
    }

    private IEnumerator MenuClose(GameObject button)
    {
        isMoving = true;

        Vector3 startPosition = button.transform.position;
        Vector3 targetPosition = this.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < slideDuration)
        {
            float t = elapsedTime / slideDuration;
            button.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        button.transform.position = targetPosition;
        button.SetActive(false);
        isMoving = false;
    }

}
