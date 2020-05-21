namespace FelipeFurlanetto_ListaM2
{
    public class Card
    {
        private string suit;
        private int value;
        private int owner; // 0 player / 1 dealer

        //construtures
        public Card(string s, int v, int o)
        {
            suit = s;
            value = v;
            owner = 0;
        }

        public Card()
        {
            suit = "";
            value = 0;
            owner = -1;
        }

        public Card(Card c)
        {
            suit = c.get_s();
            value = c.get_v();
            owner = c.get_o();
        }

        //get e set para variaveis privadas
        public void set_s(string s)
        {suit = s;}
        public void set_v(int v)
        {value = v;}
        public void set_o(int o)
        {owner = 0;}
        
        public string get_s () //retorna o naipe da carta
        {return suit;}
        public int get_v() //retorna o valor da carta
        {return value;}
        public int get_o() //retorna onde a carta está, se é na mão do jogador (0) ou dealer (1)
        {return owner;}

        //texto que representa a carta
        public override string ToString()
        {
            string card_text = "Suit: " + suit;
            card_text += "\t Value: " + value;   
            card_text += "\t Owner: " + owner;
            
            
            return  card_text;
        }
    }
}