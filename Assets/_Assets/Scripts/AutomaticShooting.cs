﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

}

public class AutomaticShooting : Shooting
{
    private const int LEFT_MOUSE_BUTTON = 0;
    private const string SHOOT_ANIMATION_PARAM_NAME = "shoot";

    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private AudioClip gunShotClip;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private Vector2 audioPitch;
    [SerializeField]
    private GameObject muzzlePrefab;
    [SerializeField]
    private Transform muzzlePosition;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform shootingPoint;

    [SerializeField]
    private GunAmmo gunAmmo;
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Camera aimingCamera;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private int rpm;
    private float interval;
    private float lastShoot;
    [SerializeField]
    private int damage;
    private List<Health> oldVictims;

    private void Start()
    {
        oldVictims = new List<Health>();
        interval = 60f / rpm;
    }

    private void Update()
    {
        if (Input.GetMouseButton(LEFT_MOUSE_BUTTON))
        {
            Debug.Log($"LEFT_MOUSE_BUTTON");
            if (gunAmmo.CanShoot && Time.time - lastShoot >= interval)
            {
                Shoot();
            }
        }
    }


    private void Shoot()
    {
        lastShoot = Time.time;
        //source.PlayOneShot(gunShotClip);
        TriggerAnimation(SHOOT_ANIMATION_PARAM_NAME);
        ShootBullet();
    }

    public void ShootBullet()
    {
        oldVictims.Clear();
        var aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            ShowHitEffect(hitInfo);
            DealDamage(hitInfo);
        }

        Instantiate(muzzlePrefab, muzzlePosition);
        gunAmmo.LoadedAmmo--;
    }

    private void ShowHitEffect(RaycastHit hitInfo)
    {
        var surface = hitInfo.collider.GetComponent<Surface>();
        if(surface)
        {
            if(!HitEffectManager.Instance)
            {
                Debug.LogError("HitEffectManager.Instance null");
                return;
            }
            var hitEffect = HitEffectManager.Instance.GetEffect(surface.type);
            var effectRotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(hitEffect, hitInfo.point, effectRotation);
        }
    }

    private void DealDamage(RaycastHit hitInfo)
    {
        var health = hitInfo.collider.GetComponentInParent<Health>();
        if (health && !oldVictims.Contains(health))
        {
            oldVictims.Add(health);
            health.TakeDamage(damage);
        }
    }

    private void TriggerAnimation(string paramName)
    {
        Debug.LogError($"trigger animation: {paramName}");
        animator.SetTrigger(paramName);
    }

}

