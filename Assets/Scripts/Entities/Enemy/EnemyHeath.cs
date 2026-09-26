using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeath : NetworkBehaviour
{
    [SerializeField] private float maxHealth;
    private float curHealth;

    public void TakeDamage(float damage)
    {
        if (isServer)
        {
            curHealth -= damage;
            if (curHealth <= 0)
            {
                NetworkServer.Destroy(gameObject);
            }
        }
    }


}
