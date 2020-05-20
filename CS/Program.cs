/*
 * Created by SharpDevelop.
 * User: Felipe
 * Date: 5/12/2020
 * Time: 18:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FelipeFurlanetto_ListaM2
{
	public class Poker
	{
		public static void Main(string[] args)
		{			
			Dealer dealer = new Dealer(); //vai precisar ...
			
			            
			Player player1 = new Player("m4rc3lo"); //constroi o player 1
            
			player1.set_full(Load.load_hand());//Lê um arquivo txt com uma carta para cada linha e seta na mão do jogador ---> Naipe ; número ; número verificador se está na mão ou na mesa (Para testar todas as situações de mão de forma controlada)
			// set_full -> seta mão cheia do player/ set_hand -> seta as cartas uma a uma
			
			Rank rank = new Rank(player1.get_hand()); //ordena e ranqueia uma lista de cartas para o jogador 1
			rank.sort();
			
			//rank.TestHistogram();

			Console.WriteLine("show sorted");
			Console.ReadKey();

			foreach (var c in rank.get_rank())  //mostra as cartas ordenadas
                Console.WriteLine(c.ToString());
			
			rank.count_values(); //conta quantidade de valores
			//Console.WriteLine("Pair test");
			rank.is_pair(); // verifica se é um par
			rank.is_sequencia(); // verifica se é uma sequência
			rank.is_naipesIguais(); // verifica se os naipes são iguais
			rank.is_cartaAlta(); // verifica e retorna a carta mais alta
			rank.is_flush(); // verifica se há 5 cartas do mesmo naipe
			rank.is_fullHouse(); // verifica se há três cartas do mesmo valor e duas outras diferentes de mesmo valor
			rank.is_quadra(); // verifica se há quatro cartas de mesmo valor e uma carta kicker
			rank.is_sFlush; // verifica se há 5 cartas em ordem numérica e se são todas do mesmo naipe
			rank.is_trinca(); // verifica se há 3 cartas do mesmo valor
			rank.is_twoPair(); // verifica se há duas cartas de um mesmo valor e outras duas cartas diferentes de mesmo valor
            
			                       
			Console.WriteLine("any key to exit");
			Console.ReadKey();
			Console.Clear(); // limpa a tela
		}
	}
	
	
}