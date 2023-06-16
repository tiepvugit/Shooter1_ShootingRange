using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenateLauncher : MonoBehaviour
{
    private const int LEFT_MOUSE_BUTTON = 0;

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
    private bool isReloaded;

    private void Start()
    {
        isReloaded = true;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON))
        {
            if (isReloaded)
            {
                isReloaded = false;
                Invoke("Reload",reloadTime);
                ShootBullet();
            }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void Reload()
    {
        isReloaded = true;
        projectTileToDisableOnFire.SetActive(true);
        reloadSource.PlayOneShot(reloadClip);
    }

    private void ShootBullet()
    {
        source.PlayOneShot(gunShotClip);
        reloadSource.PlayOneShot(reloadClip);

        var projectTile = Instantiate(projectTilePrefab, muzzlePosition.position, projectTilePrefab.transform.rotation);
        var rigidbody = projectTile.GetComponent<Rigidbody>();
        rigidbody.velocity = bulletSpeed * muzzlePosition.forward;

        projectTileToDisableOnFire.SetActive(false);
        Instantiate(muzzlePrefab, muzzlePosition);

    }



}
