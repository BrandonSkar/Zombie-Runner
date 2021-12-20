using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100.0f;


    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
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
}
