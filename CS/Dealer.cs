using System;
using System.Collections.Generic;

namespace FelipeFurlanetto_ListaM2
{
    public class Dealer
    {
        private List<Card> cards_list;
        private Stack<Card> deck;
        private Random rand;

        public Dealer()
        {
            cards_list = new List<Card>();
            deck = new Stack<Card>();
            rand = new Random();
            
            creat_deck(); // cria um deck
            shuffle(); // embaralha
            set_deck(); // Define o deck
        }

        private void creat_deck()
        {
            Card card;
            
            for (int i = 0; i < 13; i++)
            {
                card = new Card();
                card.set_v (i+1);
                card.set_s("Clubs");                             
                cards_list.Add(card);
                
                card = new Card();
                card.set_v(i+1);
                card.set_s("Diamonds");
                this.cards_list.Add(card);
                
                card = new Card();
                card.set_v(i+1);
                card.set_s("Hearts");
                this.cards_list.Add(card);
                
                card = new Card();
                card.set_v(i+1);
                card.set_s("Spades");
                this.cards_list.Add(card);
            }
        }
        public void shuffle() // Embaralha as cartas do deck
        {
            for (int i = 0 ; i < cards_list.Count -1 ; i++)
            {
                Card temp = new Card(cards_list[i]);
                int position = rand.Next(i+1, 52);

                cards_list[i] = new Card (cards_list[position]);
                cards_list[position] = new Card (temp);                
            }
        }

        
        private void set_deck() //preeche a pliha com as cartas embaralhadas
        {
           foreach (var c in cards_list)
                deck.Push(c); 
        }

        public Card get_card() 
        {return deck.Pop();}

        public void show_list() // mostra as cartas na lista cards_list
        {
            foreach (var c in cards_list)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}