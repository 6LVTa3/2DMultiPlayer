using Mirror;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MirrorManager : NetworkManager
{

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private CoinCounter coinCounterPrefab;
    [SerializeField] private CoinEmmiter coinEmmiterPrefab;
     private CoinCounter coinCounter;
     private CoinEmmiter coinEmmiter;


    public override void OnStartServer()
    {

        base.OnStartServer();

         coinCounter = Instantiate(coinCounterPrefab);
        NetworkServer.Spawn(coinCounter.gameObject);

        coinEmmiter  = Instantiate(coinEmmiterPrefab);
        NetworkServer.Spawn(coinEmmiter.gameObject);

        coinEmmiter.init(coinCounter);
    }
    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        
        base.OnServerConnect(conn);

        coinCounter.AddPlayerCounter(conn);

    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        base.OnServerDisconnect(conn);
        coinCounter.RemovePlayerCounter(conn);
    }


    public override void OnClientConnect()
    {
        

        base.OnClientConnect();
        foreach (NetworkIdentity item in NetworkServer.spawned.Values)
        {
            if (item.gameObject.TryGetComponent<CoinCounter>(out coinCounter))
            {
                break;
            }
        }


  //      coinCounter.Init(scoreText);
    }
    
}
