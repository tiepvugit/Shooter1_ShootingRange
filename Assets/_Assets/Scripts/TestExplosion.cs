using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestExplosion : MonoBehaviour
{
    private void Awake()
    {
        Debug.LogError("awake");
    }

    private void OnDestroy()
    {
        Debug.LogError("explison destroyed");
    }
}
