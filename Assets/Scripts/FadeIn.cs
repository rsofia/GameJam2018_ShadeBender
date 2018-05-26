//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public bool shouldFadeIn;
    public bool shouldFadeOut;
    public float timeToFadeIn;
    public float timeToFadeOut;
    bool isInCoroutine = false;
	void Start () 
	{
        //FadeInUI();
    }

    private void Update()
    {
        if(shouldFadeIn && !isInCoroutine)
        {
            isInCoroutine = true;
            shouldFadeIn = true;
            shouldFadeOut = false;
            FadeInUI();
        }

        if(shouldFadeOut && !isInCoroutine)
        {
            isInCoroutine = true;
            shouldFadeOut = true;
            shouldFadeIn = false;
            FadeOutUI();
        }
        
    }

    public void FadeInUI()
    {
        StartCoroutine(FadeCanvasGroupToFullAlpha(timeToFadeIn, GetComponent<CanvasGroup>()));
    }

    public void FadeOutUI()
    {
        StartCoroutine(FadeCanvasGroupToZeroAlpha(timeToFadeOut, GetComponent<CanvasGroup>()));
    }

    IEnumerator FadeCanvasGroupToFullAlpha(float t, CanvasGroup i)
    {
  

        i.blocksRaycasts = true;
        while (i.alpha < 1.0f && shouldFadeIn)
        {
            Debug.Log(gameObject.name + "Fade In: " +i.alpha);
            i.alpha = i.alpha + (Time.deltaTime / t);
            yield return new WaitForEndOfFrame();
        }
        isInCoroutine = false;
        shouldFadeIn = false;
    }
    IEnumerator FadeCanvasGroupToZeroAlpha(float t, CanvasGroup i)
    {


        i.blocksRaycasts = false;
        while (i.alpha > 0.0f && shouldFadeOut)
        {
            Debug.Log(gameObject.name + "Fade Out: " + i.alpha);
            i.alpha = i.alpha - (Time.deltaTime / t);
            yield return new WaitForEndOfFrame();
        }
        isInCoroutine = false;
        shouldFadeOut = false;

    }

    IEnumerator FadeToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return new WaitForEndOfFrame();
        }
    }
}
