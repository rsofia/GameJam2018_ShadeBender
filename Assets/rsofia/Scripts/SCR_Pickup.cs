using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SCR_Pickup : SCR_EmitSound {

    [HideInInspector]
    public float points = 0;
    public GameObject[] pickUpType;
    public float[] pickupPoints;


    [HideInInspector]
    public bool isAlive = true;

    private void Start()
    {
        int rand = Random.Range(0, pickUpType.Length);
        for(int i = 0; i < pickUpType.Length; i++)
        {
            if(i != rand)
            {
                pickUpType[i].SetActive(false);
            }
            else
            {
                pickUpType[i].SetActive(true);
                points = pickupPoints[i];
            }
        }

    }

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
