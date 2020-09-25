using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using notbloom.Random;

namespace notbloom.Lootdrop
{

    public class Deck<T>
    {

        public List<T> cards;
        public List<T> discardPile;
        public List<T> drawPile;
        // public List<T> handPile;
        // public List<T> activePile; //?

        public void Init()
        {
            discardPile = new List<T>();
            drawPile = cards.ToList();
            drawPile.Shuffle();
        }
        public void Shuffle()
        {
            drawPile = discardPile.ToList();
            discardPile = new List<T>();
            drawPile.Shuffle();
        }
        public T Draw()
        {
            T card = drawPile[0];
            drawPile.RemoveAt(0);
            return card;
        }
        public void Discard(T card) => discardPile.Add(card);


    }
}