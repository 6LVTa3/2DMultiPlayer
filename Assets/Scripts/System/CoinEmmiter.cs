using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEmmiter : NetworkBehaviour
{

    [SerializeField] private NetworkIdentity coinPrefab;
    private NetworkIdentity coin;
    private CoinCounter coinCounter;

    public void init(CoinCounter coinCounter)
    {
        this.coinCounter = coinCounter;

    }


    private void Update()
    {
        if (isServer)
        {
            if (Time.time % 5 < Time.deltaTime && coin == null)
            {
                coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
                coin.GetComponent<CoinPickUp>().Init(coinCounter);
                NetworkServer.Spawn(coin.gameObject);
                
            }
        }
    }
}
