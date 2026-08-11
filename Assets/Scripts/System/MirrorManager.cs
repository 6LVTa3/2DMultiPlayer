using Mirror;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class MirrorManager : NetworkManager
{

    [SerializeField] private CoinCounter coinCounter;

    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        
        base.OnServerConnect(conn);

        coinCounter.AddPlayerCounter(conn);
        Debug.Log(conn.ToString());
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        base.OnServerDisconnect(conn);
        coinCounter.RemovePlayerCounter(conn);
    }


    public void Test(NetworkConnectionToClient conn)
    {
        Debug.LogError("Test");
    }
}
