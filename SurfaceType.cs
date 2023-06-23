
using System;
using UnityEngine;

public enum SurfaceType 
{
        DIRD,
        BLOOD
}

[Serializable]
public  class HitEffectMapper
{
    public SurfaceType surfaceType;
    public GameObject hitEffectPfb;
}

public class HitEfectManager:MonoBehaviour
{
    public HitEfectManager[] effectMap;
}