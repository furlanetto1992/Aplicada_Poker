using System;
using System.Collections.Generic;

namespace FelipeFurlanetto_ListaM2
{

	public class Rank
	{
		private List<Card> to_rank;
		private int[] histogram;
		
				

		public Rank(List<Card> cards)
		{
			to_rank = new List<Card>();
			foreach (var c in cards)
				to_rank.Add(new Card(c));

			histogram = new int[14];
		}

		public List<Card> get_rank()
		{return to_rank;}

		public void sort() //ordena as cartas armazenadas em to_rank
		{
			int loop = to_rank.Count -1;

			for (int i = 0 ; i < loop ; i++)
			{
				bool swapped = false;
				//Console.WriteLine("For1");

				for(int j = 0 ; j < loop ; j++)
				{
					if (to_rank[j].get_v() > to_rank[j+1].get_v())
					{
						swap(j);
						swapped = true;
					}
					//Console.WriteLine("For2");
				}

				if (!swapped)
					break;				
			}
		}

		private void swap(int index)
		{	
			int i = index;
			int j = index +1;
			
			Card temp = new Card (to_rank[i]);
			to_rank[i] = new Card (to_rank[j]);
			to_rank[j] = new Card (temp);
		}

		public void count_values() //contabiliza a quantidade de valores de cartas e armazena no array histogram
		{
			for (int  i = 0 ; i < to_rank.Count ; i++)
			{
				int value = to_rank[i].get_v();
				histogram[value]++;
			}
		}

		public bool is_pair() //verifica se há um par de cartas com mesmo valor
		{
			bool ctrl = false;
			for (int i = 1 ; i < histogram.Length ; i++)
			{						
				if (histogram[i] == 2)
				{					
					Console.WriteLine("---------------------");
					Console.WriteLine("Pair found: " + i);
					Console.WriteLine("---------------------");
					ctrl = true;
				}
				//else
				//	Console.WriteLine("value: "+ i+ "Count: " + histogram[i] );
								
			}
			return ctrl;
		}
		
	/*	public void TestHistogram()
		{
			for (int  i = 0 ; i < to_rank.Count ; i++)
			{
				int value = to_rank[i].get_v();
				histogram[value]++;
				
				Console.WriteLine("--------------------");
				Console.WriteLine(histogram[value]);
				Console.WriteLine("--------------------");
			}
			
		}*/
				
		public bool is_sequencia() // verifica se há números em sequência
		{
			bool ctrl = false;
			
			int loop = to_rank.Count -1;
			int numSeg = 0;
			
			for (int i = 0 ; i < loop ; i++)
			{
				for(int j = 0 ; j < loop ; j++)
				{
					if (to_rank[j].get_v() +1 == to_rank[i].get_v()) //verifica se o valor da carta anterior +1 é igual o valor da próxima carta
					{
						numSeg++;
						if (numSeg == 5)
						{
							Console.WriteLine("---------------------"); //*** Consegui fazer funcionar, mas não entendi exatamente qual foi o erro que estava acontecendo. Basicamente mexi no txt e funcionou
							Console.WriteLine("Sequência encontrada! " + numSeg + " cartas em sequência!"); // tentei fazer algumas mudanças no código que fiz para poder mostrar as cartas da sequência, mas por algum motivo parou de checar se havia uma sequência e não consigo identificar onde está meu erro
							Console.WriteLine("---------------------");
							//Console.WriteLine("Cartas:" + histogram.Length);
							ctrl = true;
						}
					}	
					//for (int k = 1 ; k < histogram.Length ; k++)
					//{						
					//	if (histogram[k] +1 == histogram [j])
					//	{					
					//		Console.WriteLine("cartas: " + i);
					//		ctrl = true;
					//	}
						//else
						//	Console.WriteLine("value: "+ i+ "Count: " + histogram[i] );				
					//}					
				}
				ctrl = true;							
			}
			
						
			return ctrl;
		}
						
		public bool is_sFlush() // sequência de cartas do mesmo naipe
		{
			bool ctrl = false;
			
			int loop = to_rank.Count -1;
			int numSeg = 0;
			
			for (int i = 0 ; i < loop ; i++)
			{
				for(int j = 0 ; j < loop ; j++)
				{
					if (to_rank[j].get_v() +1 == to_rank[i].get_v()) //verifica se o valor da carta anterior +1 é igual o valor da próxima carta
					{
						numSeg++;
						if (numSeg == 5 && to_rank[j].get_s() == to_rank[i].get_s())
						{
							Console.WriteLine("---------------------");
							Console.WriteLine("Straight flush! " + numSeg + " cartas em sequência de mesmo naipe!"); 
							Console.WriteLine("---------------------");
							//Console.WriteLine("Cartas:" + histogram.Length);
							ctrl = true;
						}
					}	
					//for (int k = 1 ; k < histogram.Length ; k++)
					//{						
					//	if (histogram[k] +1 == histogram [j])
					//	{					
					//		Console.WriteLine("cartas: " + i);
					//		ctrl = true;
					//	}
						//else
						//	Console.WriteLine("value: "+ i+ "Count: " + histogram[i] );				
					//}					
				}
				ctrl = true;							
			}
			
						
			return ctrl;
		}
		
		public bool is_quadra() // quatro cartas de valores iguais
		{
			bool ctrl = false;
			
			for (int i = 1 ; i < histogram.Length ; i++)
			{						
				if (histogram[i] == 4)
				{					
					Console.WriteLine("---------------------");
					Console.WriteLine("Quadra found: " + i);
					Console.WriteLine("---------------------");
					ctrl = true;
				}
				//else
				//	Console.WriteLine("value: "+ i+ "Count: " + histogram[i] );
								
			}
			
			return ctrl;
		}
		
		public bool is_fullHouse() // identifica se há 3 cartas iguais e um par
		{
			bool ctrl = false;
			
			for (int i = 1 ; i < histogram.Length ; i++)
			{						
				if (histogram[i] == 3)
				{					
					bool trinca = true;
					if (trinca == true)
					{
						for (int j = 0; j < histogram.Length; j++)
						{
							if (histogram[j] == 2) 
							{
								Console.WriteLine("---------------------");
								Console.WriteLine("Full House:" + i + " e " + j);
								Console.WriteLine("---------------------");
								ctrl = true;
							} else {
								ctrl = false;
								//Console.WriteLine("TESTEEEEEEEEEEEE");
							}							
						}						
					}					
				}
				//else
				//	Console.WriteLine("value: "+ i+ "Count: " + histogram[i] );
								
			}
			
			return ctrl;
		}
		
		public bool is_flush()
		{
			bool ctrl = false;
			
			int loop = to_rank.Count -1;
			int qtd = 0;
			
			for (int i = 0 ; i < loop ; i++)
			{
				for(int j = 0 ; j < loop ; j++)
				{
					qtd ++;
					if (qtd == 5 && to_rank[j].get_s() == to_rank[i].get_s())
					{
						Console.WriteLine("---------------------");
						Console.WriteLine("Flush! " + qtd + " cartas  de mesmo naipe!"); 
						Console.WriteLine("---------------------");
						//Console.WriteLine("Cartas:" + histogram.Length);
						ctrl = true;
					}
				}	
					
			}
			ctrl = true;		
						
			return ctrl;
		}
		
		public bool is_trinca() // verifica se há uma trinca
		{
			bool ctrl = false;
			for (int i = 1 ; i < histogram.Length ; i++)
			{						
				if (histogram[i] == 3)
				{					
					Console.WriteLine("---------------------");
					Console.WriteLine("Trinca found: " + i);
					Console.WriteLine("---------------------");
					ctrl = true;
				}
				//else
				//	Console.WriteLine("value: "+ i+ "Count: " + histogram[i] );
								
			}
			return ctrl;
		}
		
		public bool is_twoPair() // verifica se há dois pares e mostra quais são as cartas
		{
			bool ctrl = false;
			int pairOne = 0;
			int pairTwo = 0;
			
			for (int i = 1 ; i < histogram.Length ; i++) // aqui eu consegui separar os pares, mas por estar no for ficam repetindo várias vezes e o valor acaba mudando para o pairOne
			{						
				if (histogram[i] == 2) 
				{					
					//Console.WriteLine("---------------------");
					//Console.WriteLine("Pair 1 found: " + i);
					//Console.WriteLine("---------------------");
					pairOne = i;
					
					for (int j = i; j < histogram.Length; j++)
					{
						if (histogram[j] == 2)
						{
							//Console.WriteLine("---------------------");
							//Console.WriteLine("Pair 2 found: " + j);
							//Console.WriteLine("---------------------");
							pairTwo = j;
							ctrl = true;
						} 
					}					
				}
				
				
				//else
				//	Console.WriteLine("value: "+ i+ "Count: " + histogram[i] );
								
			}
			
			if (ctrl == true)
				{
					Console.WriteLine("---------------------");
					Console.WriteLine("two Pair Found: " + pairOne + " and " + pairTwo); //aqui eu consegui mostrar quais são os pares, mas ao tirar do for os dois pares ficam iguais ao par de maior valor, ainda não consegui resolver
					Console.WriteLine("---------------------");
				}
			
			return ctrl;
		}
		
		public bool is_cartaAlta() // verifica qual a carta mais alta em jogo
		{
			bool ctrl = false;
			int cartaAlta = 0;
			
			
			for (int k = 1 ; k < histogram.Length ; k++)
				{						
					for (int i = 0; i < histogram.Length; i++) 
					{
						for (int j = 0; j < histogram.Length; j++) {
							if (histogram[k] +1 == histogram [j])
							{					
								cartaAlta = j;
								ctrl = true;
							}
					//else
					//	Console.WriteLine("value: "+ i+ "Count: " + histogram[i] );
						}
					}									
				}
			
			Console.WriteLine("---------------------");
			Console.WriteLine("Carta mais alta: "+ cartaAlta);
			Console.WriteLine("---------------------");			
			
								
			return ctrl;
			
			
		}
		
		
	}
}