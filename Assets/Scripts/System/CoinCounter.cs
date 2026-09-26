using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class CoinCounter : NetworkBehaviour
{
    [SerializeField] private UIScore prefabUIScore;

    private UIScore uiScore;
    private TextMeshProUGUI scoreText;
    private Dictionary<NetworkConnectionToClient, int> playerScores;
    private int count;

    public void AddCoin()
        => count++;

    public void Init(TextMeshProUGUI text)
    {
        scoreText = text;


    }
    private void Awake()
    {

            playerScores = new Dictionary<NetworkConnectionToClient, int>();
        Debug.Log(NetworkClient.spawned.Count + " Count");
        uiScore = Instantiate(prefabUIScore);
    }
  
   public void AddPlayerCounter(NetworkConnectionToClient client)
    {
        Debug.Log(playerScores);
        playerScores.Add(client, 0);
        Debug.Log(playerScores);
       
    }

  
    public void RemovePlayerCounter(NetworkConnectionToClient client)
    {
      
            playerScores.Remove(client);
            Debug.Log("Ping");
        
    }

    [Server]
    public void AddCoinSend(NetworkConnectionToClient client)
    {
        if (playerScores.ContainsKey(client))
        {
            playerScores[client] += 1;
            AddCoinRecive(client, playerScores[client]);
            Debug.Log("Ping");
        }

    }

    [TargetRpc]
    private void AddCoinRecive(NetworkConnectionToClient client, int score)
    {
        Debug.Log(score); 
        uiScore.UpdateScore(score);
    }

    private void OnDestroy()
    {
        Destroy(uiScore.gameObject);
    }
}
