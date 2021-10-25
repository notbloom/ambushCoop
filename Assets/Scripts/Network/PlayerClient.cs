using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerClient : NetworkBehaviour
{
    public string unique_id;
    public string player_name;
    public PlayerAgent playerAgent;
    public ScriptableCard playingCard;
    public short avatarRID; //REPOSITORY ID    
    public Sprite avatar => GlobalRepositorySystem.PlayerAvatar(avatarRID);

    public string[] deck = { "FireBall", "Move5Card", "Cleave3" };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // this is called on the server
    [Command]
    void CmdChooseAvatar(short avatarIndex)
    {
        RPCChangeAvatar(avatarIndex);
    }
    // This is called to all clients
    [ClientRpc]
    void RPCChangeAvatar(short avatarIndex) {
        avatarRID = avatarIndex;
    }

}
