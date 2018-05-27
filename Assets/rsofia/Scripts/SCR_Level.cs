using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Level : MonoBehaviour {

    public float estimatedTimeInSeconds = 30;
    public float tiempoACambiar = 7;
    public bool lerpEnemies = true;

    private void Start()
    {
        if (lerpEnemies)
            LeanTween.pauseAll();
    }

}
