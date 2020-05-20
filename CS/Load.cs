using System;
using System.IO;
using System.Collections.Generic;


namespace FelipeFurlanetto_ListaM2
{
	public static class Load
	{
		public static List<Card> load_hand()
		{
			Console.WriteLine("\nDigite o nome do arquivo");
			string path_file = Console.ReadLine();
			List<Card> cards = new List<Card>();

			
        	string[] readText = File.ReadAllLines(path_file);       	
        	

        	foreach(var s in readText)
        	{
        		string[] line = s.Split(';');
        		{        			
        			Card card = new Card( line[0], int.Parse(line[1]), int.Parse(line[2]) );
        			cards.Add(card);
        			Console.WriteLine(card.ToString());
        		}
        	}        	
        	return cards;
		}
				
	}
}