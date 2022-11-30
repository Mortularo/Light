using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int EnemyMaxHealth = 50;

    internal void Damage(int damage)
    {
        Debug.Log(message: "Hit:" + damage);
        EnemyMaxHealth -= damage;
        if (EnemyMaxHealth <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Destroy(gameObject, 10f);
    }
}
