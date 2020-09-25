using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "VisibleCharacter", menuName = "Char/VisibleCharacter", order = 0)]
public class VisibleCharacter : ScriptableObject
{
    public Sprite sprite;
    public new string name;
}
