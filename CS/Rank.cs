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
					Console.WriteLine("Pair found: " + i);
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
		
		public bool is_naipesIguais() 
		{
			bool ctrl = false;				
			return ctrl;
		}
		
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
							Console.WriteLine("Straight Flush! " + numSeg + " cartas em sequência!"); // tentei fazer algumas mudanças no código que fiz para poder mostrar as cartas da sequência, mas por algum motivo parou de checar se havia uma sequência e não consigo identificar onde está meu erro
							//Console.WriteLine("Cartas:" + histogram.Length);
							ctrl = true;
						}
					}	
					/*for (int k = 1 ; k < histogram.Length ; k++)
					{						
						if (histogram[k] +1 == histogram [j])
						{					
							Console.WriteLine("cartas: " + i);
							ctrl = true;
						}
						//else
						//	Console.WriteLine("value: "+ i+ "Count: " + histogram[i] );				
					}*/					
				}
				ctrl = true;							
			}
			
						
			return ctrl;
		}
						
		public bool is_sFlush()
		{
			bool ctrl = false;
			return ctrl;
		}
		
		public bool is_quadra()
		{
			bool ctrl = false;
			return ctrl;
		}
		
		public bool is_fullHouse()
		{
			bool ctrl = false;
			return ctrl;
		}
		
		public bool is_flush()
		{
			bool ctrl = false;
			return ctrl;
		}
		
		public bool is_trinca()
		{
			bool ctrl = false;
			return ctrl;
		}
		
		public bool is_twoPair()
		{
			bool ctrl = false;
			return ctrl;
		}
		
		public bool is_cartaAlta()
		{
			bool ctrl = false;
			return ctrl;
		}
		
		
	}
}