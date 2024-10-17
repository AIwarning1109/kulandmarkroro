using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    public static HitManager instance;
    public int numKills;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
