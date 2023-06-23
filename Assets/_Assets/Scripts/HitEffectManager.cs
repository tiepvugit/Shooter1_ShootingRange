using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HitEffectManager : Singleton<HitEffectManager>
{
    [SerializeField]
    private HitEffectMapper[] _effectMap;
    private Dictionary<SurfaceType, HitEffectMapper> _effectDict;

    protected override void Init()
    {
        _effectDict = _effectMap.ToDictionary(effect => effect.surfaceType);
    }

    public GameObject GetEffect(SurfaceType type)
    {
        if(_effectDict.ContainsKey(type))
        {
            return _effectDict[type].effectPfb;
        }
        return null;
    }
}