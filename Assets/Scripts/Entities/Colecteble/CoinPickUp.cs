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
        if (isServer)
        {
            coinCounter.AddCoinSend(collision.GetComponent<NetworkIdentity>().connectionToClient);
            NetworkServer.Destroy(gameObject);


        }

    }


}
