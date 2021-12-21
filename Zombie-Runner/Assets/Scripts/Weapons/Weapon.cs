using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100.0f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        DisplayAmmo();
        if (Input.GetButtonDown("Fire1") && ammoSlot.GetCurrentAmmo(ammoType) > 0 && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        ammoText.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        ammoSlot.ReduceCurrentAmmo(ammoType);
        PlayMuzzleFlash();
        ProcessRaycast();

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHiteImpact(hit);
            //TODO: add some hit effect
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;

            target.TakeDamage(damage);
            //call a method on enemyhealth to decrease enemy health
        }
        else
        {
            return;
        }
    }

    private void CreateHiteImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
