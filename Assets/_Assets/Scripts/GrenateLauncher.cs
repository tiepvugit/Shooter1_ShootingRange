using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenateLauncher : MonoBehaviour
{
    private const int LEFT_MOUSE_BUTTON = 0;
    private const string SHOOT_ANIMATION_PARAM_NAME = "shoot";

    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private AudioClip gunShotClip;
    [SerializeField]
    private AudioClip reloadClip;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioSource reloadSource;
    [SerializeField]
    private Vector2 audioPitch;
    [SerializeField]
    private GameObject muzzlePrefab;
    [SerializeField]
    private Transform muzzlePosition;
    [SerializeField]
    private GameObject projectTilePrefab;
    [SerializeField]
    private GameObject projectTileToDisableOnFire;

    [SerializeField]
    private float reloadTime;
    [SerializeField]
    private GunAmmo gunAmmo;
    [SerializeField]
    private Animator animator;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON))
        {
            if (gunAmmo.CanShoot)
            {
                Shoot();
            }
        }
    }


    private void Shoot()
    {
        source.PlayOneShot(gunShotClip);
        reloadSource.PlayOneShot(reloadClip);
        TriggerAnimation(SHOOT_ANIMATION_PARAM_NAME);
    }

    public void ShootBullet()
    {
        var projectTile = Instantiate(projectTilePrefab, muzzlePosition.position, projectTilePrefab.transform.rotation);
        var rigidbody = projectTile.GetComponent<Rigidbody>();
        rigidbody.velocity = bulletSpeed * muzzlePosition.forward;

        Instantiate(muzzlePrefab, muzzlePosition);
        gunAmmo.LoadedAmmo--;
    }

    private void TriggerAnimation(string paramName)
    {
        Debug.LogError($"trigger animation: {paramName}");
        animator.SetTrigger(paramName);
    }

}
