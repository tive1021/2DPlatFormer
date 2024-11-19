using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCondition : MonoBehaviour
{
    public int health = 2;
    [SerializeField] private int maxHealth = 3;

    public void Heal()
    {
        if(health < maxHealth)
            health++;
    }

    public void OnDamage()
    {
        health--;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("ав╬З╫ю╢о╢ы.");
        Destroy(gameObject);
    }
}
