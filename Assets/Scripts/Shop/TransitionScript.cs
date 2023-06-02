using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScript : MonoBehaviour
{
    public GameObject transitionScreen;
    private Material screenMaterial;
    private Color screenColor;
    private bool inputEnabled;

    public GameObject displayFish;
    public GameObject fishName;
    public GameObject continueText;

    public GameObject buyButtonObject;

    private void OnEnable()
    {
        StartCoroutine(EnableInputWithDelay());
    }

    private IEnumerator EnableInputWithDelay()
    {
        yield return new WaitForSeconds(1.6f); // Add a delay of 2 seconds

        inputEnabled = true;
    }

    public void OnMouseDown()
    {
        if (inputEnabled)
        {
            StartCoroutine(HideTransitionScreen());
        }
    }

    private IEnumerator HideTransitionScreen()
    {
        Destroy(displayFish);
        Renderer screenRenderer = transitionScreen.GetComponent<Renderer>();
        continueText.SetActive(false);
        fishName.SetActive(false);
        transitionScreen.SetActive(false);
        screenMaterial = screenRenderer.material;
        screenColor = screenMaterial.color;
        screenColor.a = 0f;
        screenMaterial.color = screenColor;
        inputEnabled = false;
        Button buyButton = buyButtonObject.GetComponent<Button>();
                if (buyButton != null)
                {
                buyButton.enabled = true;
                Debug.Log("Button disabled for " + buyButtonObject.name);
                }
                else
                {
                 Debug.LogWarning("Target object does not have a button!");
                }
        yield return new WaitForSeconds(1.0f);
    }
}
