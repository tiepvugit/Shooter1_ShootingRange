using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GunAmmo : MonoBehaviour
{
    private const string RELOAD_ANIMATION_PARAM_NAME = "reload";
    [SerializeField]
    private int magSize;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private AudioSource reloadSource;
    [SerializeField]
    private UnityEvent<int> onReloadAmmoChanged;
    [SerializeField]
    private Shooting shooting;

    private void Start()
    {
        UnlockeShooting();
    }

    private int _loadedAmmo;
    public int LoadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            _loadedAmmo = value;
            onReloadAmmoChanged?.Invoke(_loadedAmmo);
            if(_loadedAmmo <=0)
            {
                ReloadAmmo();
            }
            else
            {
                UnlockeShooting();
            }
        }
    }

    public bool CanShoot
    {
        get; private set;
    }

    private void UnlockeShooting()
    {
        shooting.enabled = true;
        CanShoot = true;
    }

    private void LockShooting()
    {
        shooting.enabled = false;
    }

    private void ReloadAmmo()
    {
        print("Reload");
        CanShoot = false;
        TriggerAnimation(RELOAD_ANIMATION_PARAM_NAME);
        reloadSource.Play();
    }

    public void OnReloaded()
    {
        print("OnReloaded");
        LoadedAmmo = magSize;
    }

    private void TriggerAnimation(string paramName)
    {
        Debug.LogError($"trigger animation: {paramName}");
        animator.SetTrigger(paramName);
    }
}
