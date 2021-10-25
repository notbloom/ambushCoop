using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "VisibleObject", menuName = "Char/VisibleObject", order = 0)]
public class VisibleObject : ScriptableObject
{
    public Sprite sprite;
    public new string name;

    public Color initiativeColorOnTurn;
    public Color initiativeColorOffTurn;
}
