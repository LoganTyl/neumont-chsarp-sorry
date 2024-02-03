using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Generate Cards for the Deck, Stores them and has a way of drawing the cards
/// </summary>

namespace Sorry
{
    public class CardDeck
    {
        //Class Level Variables
        private List<Card> cardDeck = new List<Card>();
        private List<Card> discardDeck = new List<Card>();
        private int count = 0;
        public enum Card { One, Two, Three, Four, Five, Seven, Eight, Ten, Eleven, Twelve, Sorry };

        public CardDeck()
        {
            generateAndStoreCards(Card.One);
            generateAndStoreCards(Card.Two);
            generateAndStoreCards(Card.Three);
            generateAndStoreCards(Card.Four);
            generateAndStoreCards(Card.Five);
            generateAndStoreCards(Card.Seven);
            generateAndStoreCards(Card.Eight);
            generateAndStoreCards(Card.Ten);
            generateAndStoreCards(Card.Eleven);
            generateAndStoreCards(Card.Twelve);
            generateAndStoreCards(Card.Sorry);
            shuffle();

        }

        public void generateAndStoreCards(Card card)
        {
            for (int i = count; i < (count + 4); i++)
            {
                cardDeck.Add(card);
            }
            shuffle();
            count += 4;
        }

        public void shuffle()
        {
            Random rand = new Random();
            int size = cardDeck.Count;
            while (size > 1)
            {
                size--;
                int index = rand.Next(size + 1);
                Card value = cardDeck[index];
                cardDeck[index] = cardDeck[size];
                cardDeck[size] = value;
            }
        }

        public void reshuffle()
        {
            for (int i = 0; i < discardDeck.Count; i++)
            {
                Random rand = new Random();
                int value = 0;
                value = rand.Next(discardDeck.Count);
                addToCardDeck(value);
            }
        }

        public void addToCardDeck(int index)
        {
            Card newCard = discardDeck[index];
            discardDeck.RemoveAt(index);
            cardDeck.Add(newCard);
        }

        public Card drawCard()
        {
            Card newcard = new Card();
            if (cardDeck.Any())
            {
                newcard = cardDeck[0];
                cardDeck.RemoveAt(0);
                discardDeck.Add(newcard);
                return newcard;
            }
            else
            {
                reshuffle();
                return cardDeck[1];
            }

            //return newcard;
        }
        public int CardNum()
        {
            if (discardDeck.Last() == Card.One)
            {
                return 1;
            }
            else if (discardDeck.Last() == Card.Two)
            {
                return 2;
            }
            else if (discardDeck.Last() == Card.Three)
            {
                return 3;
            }
            else if (discardDeck.Last() == Card.Four)
            {
                return 4;
            }
            else if (discardDeck.Last() == Card.Five)
            {
                return 5;
            }
            else if (discardDeck.Last() == Card.Seven)
            {
                return 7;
            }
            else if (discardDeck.Last() == Card.Eight)
            {
                return 8;
            }
            else if (discardDeck.Last() == Card.Ten)
            {
                return 10;
            }
            else if (discardDeck.Last() == Card.Eleven)
            {
                return 11;
            }
            else
            {
                return 12;
            }
        }

    }
}