using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    //create a public method that reduces hitpoints by the amount of damage
    public void TakeDamage(int damage)
    {
        BroadcastMessage("OnDamageTaken");

        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;

        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
