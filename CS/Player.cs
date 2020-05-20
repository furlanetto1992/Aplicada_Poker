using System;
using System.Collections.Generic;

namespace FelipeFurlanetto_ListaM2
{
    public class Player
    {
        private String name;        
        private List<Card> hand;

        public Player()
        {
            name = "";
            hand = new List<Card>();
        }

        public Player(String n)
        {
            name = n; 
            this.hand = new List<Card>();
        }

        public String get_name ()
        {
            return this.name;
        }

        public void set_name(String n)
        {
            this.name = n;
        }

        public void set_hand(Card c)
        {
            this.hand.Add(c);
        }

        public List<Card> get_hand()
        {
            return hand;
        }

        public void set_full(List<Card> cards)
        {
            hand = cards;
        }
    }
}