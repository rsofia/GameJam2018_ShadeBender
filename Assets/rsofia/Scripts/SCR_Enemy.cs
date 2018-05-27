using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Enemy : SCR_EmitSound {

    public int damage = 1;
    [Tooltip("This is the world position in x")]
    public float positionToLean = 3;
    private float timeToLean = 3;
       
    private void Start()
    {
        positionToLean = transform.position.x + 2;
        if(FindObjectOfType<SCR_Level>().lerpEnemies)
            LeanTween.moveX(gameObject, positionToLean, timeToLean).setLoopPingPong();
    }
}
