using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DeckAnimator : MonoBehaviour
{
    [Header("Card Buffer")]
    public GameObject cardPrefab;
    public List<GameObject> buffer;

    [Header("Transform Positions")]
    public Transform deckTransform;
    public Transform discardTransform;
    public Transform handTransform;
    public Transform playTransform;
    public Transform playThreshold;
    public List<CardAnimationView> handCards;
    public CardAnimationView playingCard;
    public float handSpacing = 0.2f;
    public float verticalHighlight = 0.1f;

    public CardAnimationView highlightedCard{
        get { return _highlightedCard; }
        set {   _highlightedCard = value;
            UpdateHandPositions();
        }
    }
    private CardAnimationView _highlightedCard;
    public static DeckAnimator instance;
    void Awake() {         
        if (instance == null) {
            instance = this;
        }
        buffer = new List<GameObject>();
    }
    public void CancelPlayedCard() { 
        playingCard.playing = false;
        playingCard = null;
        UpdateHandPositions();
    }
    public void OnPlayedCard() {
        handCards.Remove(playingCard);
        playingCard.playing = false;
        playingCard.position =  discardTransform.position;
        playingCard.rotation = discardTransform.rotation;
        playingCard = null;
        UpdateHandPositions();
    }
    public void PlayCard(CardAnimationView card) {
        if (playingCard != null) { 
            CancelPlayedCard();
        }
        card.playing = true;
        playingCard = card;
        card.transform.position = playTransform.position;
        card.transform.rotation = playTransform.rotation;
    }
    public GameObject CardFromBuffer() { 
        GameObject cardGameObject;
        if (buffer.Count == 0)
        {
            cardGameObject = Instantiate(cardPrefab, deckTransform.position, deckTransform.rotation);
            cardGameObject.transform.parent = transform;
            cardGameObject.GetComponent<CardAnimationView>().deckAnimator = this;
        }
        else
        {
            cardGameObject = buffer[0];
            buffer.Remove(cardGameObject);
            cardGameObject.SetActive(true);
        }        
        return cardGameObject;
    }
    public void RemoveAndAddToBuffer(GameObject cardGameObject)
    {
        cardGameObject.SetActive(false);
        cardGameObject.transform.position = new Vector3(-10000, -10000, -10000);
        if (!buffer.Contains(cardGameObject))
            buffer.Add(cardGameObject);
    }
    public void DrawSixCards() {        
        DrawCards(new string[]{"FireBall", "Move5Card", "Cleave3"});        
    }
    public void DrawCards(string[] cards) {
        foreach (string card in cards) {
            DrawCard(card);
        }
    }
    public void DrawCard(string card) {
        GameObject cardGameObject = CardFromBuffer();
        CardAnimationView newCard = cardGameObject.GetComponent<CardAnimationView>();
        newCard.PopulateView(card);
        newCard.transform.position = deckTransform.position;
        newCard.transform.rotation = deckTransform.rotation;
        handCards.Add(newCard);
        UpdateHandPositions();
    }
    public void UpdateHandPositions() {
        for (var i = 0; i < handCards.Count; i++)
        {
            handCards[i].position = HandPosition(i, handCards.Count, handSpacing);
            handCards[i].rotation = handTransform.rotation;
        }
        if (highlightedCard != null) {
            highlightedCard.position.y = handTransform.position.y + verticalHighlight;
            highlightedCard.rotation = handTransform.rotation;
        }
    }
    public void DiscardHand() {
        foreach (CardAnimationView card in handCards)
        {
            card.position = discardTransform.position;
            card.rotation = discardTransform.rotation;
        }
        handCards = new List<CardAnimationView>();
    }
    public Vector3 HandPosition(float i, float n, float spacing){
        var x = handTransform.position.x - (n - 1) / 2.0f * spacing + i*spacing;
        return new Vector3(x, handTransform.position.y, handTransform.position.z);
    }
}
