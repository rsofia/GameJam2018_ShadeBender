using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Level : MonoBehaviour {

    public static float estimatedTimeInSeconds = 30;
    public static float tiempoACambiar = 7;
    public static bool lerpEnemies = true;
    public static int index;

    private void Start()
    {
        if (lerpEnemies)
            LeanTween.pauseAll();
    }

}
