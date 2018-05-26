//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeText : MonoBehaviour {

    public Text TXT_Subtitle;
    public static bool canStart = false;
    public static bool hasStarted = false;

    bool isVisible = false;
    
    
    private void Start()
    {
        StartCoroutine(FadeTextToFullAlpha(4f, GetComponent<Text>()));
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    StartCoroutine(FadeTextToFullAlpha(3f, GetComponent<Text>()));
        //}
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    StartCoroutine(FadeTextToZeroAlpha(2f, GetComponent<Text>()));
        //}

        if(hasStarted && canStart)
        {
            StartCoroutine(FadeTextToZeroAlpha(3f, GetComponent<Text>()));
            StartCoroutine(FadeTextToZeroAlpha(3f, TXT_Subtitle));
            Invoke("LoadNextScene", 3.5f);
            canStart = false;
        }
    }

    public void  LoadNextScene()
    {
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator WaitToChange()
    {
        if(!hasStarted)
        {
            if (isVisible)
                StartCoroutine(FadeTextToZeroAlpha(2f, TXT_Subtitle));
            else
                StartCoroutine(FadeSubTextToFullAlpha(2f, TXT_Subtitle));
        }
        
        isVisible = !isVisible;

        yield return new WaitForSeconds(2f);

        StartCoroutine(WaitToChange());

    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(WaitToChange());
    }

    public IEnumerator FadeSubTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return new WaitForEndOfFrame();
        }

        canStart = true;
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return new WaitForEndOfFrame();
        }
    }
}
