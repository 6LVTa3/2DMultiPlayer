using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            Debug.LogWarning("isOwned");
        }

        Debug.LogError(NetworkClient.spawned.ElementAt(0).Value.gameObject);


        foreach (var (key,value) in NetworkClient.spawned)
        {

            if (value.TryGetComponent<CoinCounter>(out coinCounter))
            {
                Debug.LogWarning("isFound");
                break;

            }
        }

            
        try
        {
            coinCounter.AddCoinSend(collision.GetComponent<NetworkIdentity>().connectionToClient);
        }
        catch 
        {

            Debug.LogError("coinCounter.AddCoinSend(collision.GetComponent<NetworkIdentity>().connectionToClient) is not working");
        }
            NetworkServer.Destroy(gameObject);


    }


}
