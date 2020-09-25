using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StatusExpiration
{
    turnEnd, tickOnTurnEnd, tickOnTurnStart, tickOnRoundEnd, never
}
[CreateAssetMenu(fileName = "Status", menuName = "Char/Status", order = 0)]

public class Status : ScriptableObject
{
    public Sprite icon;
    public StatusExpiration expiration;
    public int ticks = 0;

}
