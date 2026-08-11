using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : NetworkBehaviour
{
    private CoinCounter coinCounter;

    public void Init(CoinCounter coinCounter)
    {
        this.coinCounter = coinCounter;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(coinCounter);

        if (collision.GetComponent<NetworkIdentity>().isOwned)
        {
            Debug.LogError("isOwned");
        }

        foreach (var (key,value) in NetworkClient.spawned)
        {
            if (value.TryGetComponent<CoinCounter>(out coinCounter))
            {
                break;
            }
        }

            coinCounter.AddCoinSend(collision.GetComponent<NetworkIdentity>().connectionToClient);
            NetworkServer.Destroy(gameObject);


    }


}
