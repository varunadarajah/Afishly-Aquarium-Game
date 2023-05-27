using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBarScript : MonoBehaviour
{
    public List<GameObject> menuButtons;
    public GameObject bgBox;
    public GameObject bgCircle;

    public float targetYPosition = -0.76f;
    public float targetBgBoxPosition = -0.509f;
    public float slideDuration = 1f;

    public Vector3 returnPosition = new Vector3(0f, 0f);

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
                    targetYPosition += 0.155f;
                }
                targetYPosition = targetBgBoxPosition;
                StartCoroutine(MenuOpen(bgBox));
                bgCircle.SetActive(false);
                isOpen = true;
                targetYPosition = -0.76f;
            } 
            else
            {
                foreach (GameObject button in menuButtons)
                {
                    StartCoroutine(MenuClose(button));                    
                }
                StartCoroutine(CloseBGBox(bgBox));                
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

    private IEnumerator CloseBGBox(GameObject button)
    {
        isMoving = true;

        Vector3 startPosition = button.transform.localPosition;
        Vector3 targetPosition = returnPosition;
        float elapsedTime = 0f;

        while (elapsedTime < slideDuration)
        {
            float t = elapsedTime / slideDuration;
            button.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        button.transform.localPosition = targetPosition;
        button.SetActive(false);
        bgCircle.SetActive(true);
        isMoving = false;
    }

}
