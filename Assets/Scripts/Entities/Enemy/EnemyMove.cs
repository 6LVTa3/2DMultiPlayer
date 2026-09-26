using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] NetworkIdentity identity;

    private Transform target;

    private void Update()
    {
        if (target != null && identity.isServer)
        {
            transform.position +=(target.position - transform.position).normalized * speed * Time.deltaTime;
        }
    }
}
