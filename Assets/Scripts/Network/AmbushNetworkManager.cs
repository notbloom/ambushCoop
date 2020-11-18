using UnityEngine;
using Mirror;
using System.Collections.Generic;
using System;
//[AddComponentMenu("NetworkManagerAmbush")]
public class AmbushNetworkManager : NetworkManager
{
    [Header("Custom Fields")]
    public List<PlayerClient> playerClients;
    public int addedPlayers = 0;
    public Action OnPlayerListUpdated;

    //public override void OnClientDisconnect(NetworkConnection conn)
    //{
    //    base.OnClientDisconnect(conn);
    //}
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        Debug.Log("PLAYER ADDED");
        //GENERATE ID FOR NEW PLAYER
        string player_id = "Player-"+addedPlayers.ToString();

        //Spawn the PlayerClient
        GameObject player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);        
        NetworkServer.AddPlayerForConnection(conn, player);

        PlayerClient playerClient = player.GetComponent<PlayerClient>();
        playerClient.unique_id = player_id;

        playerClients.Add(playerClient);
        addedPlayers++;

        OnPlayerListUpdated?.Invoke();

        //// spawn ball if two players
        //if (numPlayers == 2)
        //{
        //    ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));
        //    NetworkServer.Spawn(ball);
        //}
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        //// destroy ball
        //if (ball != null)
        //    NetworkServer.Destroy(ball);

        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }
}
