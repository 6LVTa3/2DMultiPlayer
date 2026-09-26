using Mirror;
using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MirrorManager : NetworkManager
{

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private CoinCounter coinCounterPrefab;
    [SerializeField] private CoinEmmiter coinEmmiterPrefab;
    [SerializeField] private EnemyEmmiter enemyEmmiterPrefab;
    private CoinCounter coinCounter;
    private CoinEmmiter coinEmmiter;
    private EnemyEmmiter enemyEmmiter;


    public override void OnStartServer()
    {

        base.OnStartServer();

         coinCounter = Instantiate(coinCounterPrefab);
        NetworkServer.Spawn(coinCounter.gameObject);

        coinEmmiter  = Instantiate(coinEmmiterPrefab);
        NetworkServer.Spawn(coinEmmiter.gameObject);

        coinEmmiter.init(coinCounter);

        enemyEmmiter = Instantiate(enemyEmmiterPrefab);
        NetworkServer.Spawn(enemyEmmiter.gameObject);
    }
    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        
        base.OnServerConnect(conn);
        StartCoroutine(AddPlayer(conn));
    

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
                coinCounter.Init(scoreText);
                Debug.Log("CoinCounter Inited");
                break;
            }
        }



    }

    private IEnumerator AddPlayer(NetworkConnectionToClient conn)
    {
        while (coinCounter == null)
        {
            yield return null;
        }
        coinCounter.AddPlayerCounter(conn);
    }
    
    
}
