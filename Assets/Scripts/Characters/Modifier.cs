using UnityEngine;

[CreateAssetMenu(fileName = "Modifier", menuName = "Char/Modifier", order = 0)]
public class Modifier : ScriptableObject
{
    public bool Override;
    public int Base;
    public int Add;

}
