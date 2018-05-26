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

	void Start () 
	{
        //FadeInUI();
    }

    private void Update()
    {
        if(shouldFadeIn)
        {
            FadeInUI();
            shouldFadeIn = false;
        }

        if(shouldFadeOut)
        {
            FadeOutUI();
            shouldFadeOut = false;
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
        while (i.alpha < 1.0f)
        {
            i.alpha = i.alpha + (Time.deltaTime / t);
            yield return null;
        }
    }
    IEnumerator FadeCanvasGroupToZeroAlpha(float t, CanvasGroup i)
    {
        i.blocksRaycasts = false;
        while (i.alpha > 0.01f)
        {
            i.alpha = i.alpha - (Time.deltaTime / t);
            yield return null;
        }
    }

    IEnumerator FadeToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
}
