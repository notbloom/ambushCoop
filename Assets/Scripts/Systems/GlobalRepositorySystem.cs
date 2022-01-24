using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalRepositorySystem : MonoBehaviour
{
    public List<Sprite> playerAvatars;
    static GlobalRepositorySystem instance;

    //void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //}

    //public int AvatarID(Sprite playerAvatar)
    //{
    //    return playerAvatars.IndexOf(playerAvatar);
    //}


    //public static Sprite PlayerAvatar(short spriteID) {
    //    if (spriteID < 0 || spriteID >= instance.playerAvatars.Count)
    //        return null;
    //    return instance.playerAvatars[spriteID];
    //}

    //// public static ScriptableCard Card(string cardID) {
    ////     return Resources.Load("Cards/" + cardID, typeof(ScriptableCard)) as ScriptableCard;
    //// }
    //void Update()
    //{
        
    //}
}
