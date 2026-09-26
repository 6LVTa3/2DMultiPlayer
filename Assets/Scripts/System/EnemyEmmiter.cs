using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyEmmiter : NetworkBehaviour
{
    [SerializeField] private float cooldown = 1;
    [SerializeField] private float spawnDistance = 1;
    [SerializeField] private float spawnTime = 1;
    [SerializeField] private bool DEBUGIsActive;
    [SerializeField] private int enemyLimit = 4;
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    

    //private List<EnemyList> enemies;


    private void Update()
    {
        if (!DEBUGIsActive) return;

        if (Time.time % cooldown < Time.deltaTime && isServer)
        {
            for (int i = 0; i < spawnPoints.Count; ++i)
            {
                Vector3 spawnPos = spawnPoints[i].position + new Vector3((float)Random.Range(0, 100) / 100, (float)Random.Range(0, 100) / 100, 0);
                Debug.Log(spawnPos);
            }
        }
    }
}