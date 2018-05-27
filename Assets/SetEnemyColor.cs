//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemyColor : MonoBehaviour {

    void OnEnable()
    {
        if (gameObject.layer == 8)
        {
            GetComponentInChildren<SkinnedMeshRenderer>().material.SetColor("_Color", SCR_CustomizationColor.colorAngel);
        }

        if (gameObject.layer == 9)
        {
            GetComponentInChildren<SkinnedMeshRenderer>().material.SetColor("_Color", SCR_CustomizationColor.colorDemon);
        }
    }
}
