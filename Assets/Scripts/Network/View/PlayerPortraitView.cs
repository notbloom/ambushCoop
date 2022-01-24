using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPortraitView : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public Image portraitImage;

    public void Populate(string name, Sprite sprite)
    {
        playerName.text = name;
        portraitImage.sprite = sprite;
    }
}