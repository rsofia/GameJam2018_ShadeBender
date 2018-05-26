using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Enemy : SCR_EmitSound {

    public int damage = 1;
    public float positionToLean = 3;
    private float timeToLean = 3;
       
    private void Start()
    {
        LeanTween.moveX(gameObject, positionToLean, timeToLean).setLoopPingPong();
    }
}
