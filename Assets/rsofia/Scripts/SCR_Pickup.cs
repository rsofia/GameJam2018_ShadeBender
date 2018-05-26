using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SCR_Pickup : SCR_EmitSound {

    public float points = 10;
    public bool isAlive = true;
    

    public void Pick()
    {
        isAlive = false;
        PlaySound();
        StartCoroutine(WaitToKill());
    }

    private void Kill()
    {
        Destroy(gameObject);
    }

    IEnumerator WaitToKill()
    {
        // yield return new WaitWhile(() => source.isPlaying);
        yield return new WaitForSeconds(0.1f);
        Kill();
    }
}
