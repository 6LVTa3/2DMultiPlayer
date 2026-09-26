using Mirror;
using Mirror.BouncyCastle.Asn1.Misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
    [SerializeField] private int dmg;
    [SerializeField] private float spd = 1;
    [SerializeField] private float dst = 1;

    private float startSpawnTime;

    private void Start()
    {
        startSpawnTime = Time.time;
    }
    private void Update()
    {
        if (isServer)
        {
            transform.position += transform.right * spd * Time.deltaTime;
            if (Time.time - startSpawnTime > dst / spd)
            {
                NetworkServer.Destroy(gameObject);
            }
        }
    }


}
