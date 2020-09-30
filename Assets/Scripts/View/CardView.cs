using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class CardView : MonoBehaviour, IPointerDownHandler
{

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI cost;
    public ScriptableCard card;
    // Start is called before the first frame update
    void Start()
    {
        PopulateView();
    }

    public void PopulateView()
    {
        title.text = card.title;
        description.text = card.description;
        cost.text = card.cost.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(card.title + " Was Clicked.");
        AreaView.OnCardActivate(card);
    }

}