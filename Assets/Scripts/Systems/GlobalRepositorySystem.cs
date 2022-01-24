using System.Collections.Generic;
using UnityEngine;

public class GlobalRepositorySystem : MonoBehaviour
{
    private static GlobalRepositorySystem instance;
    public List<Sprite> playerAvatars;

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