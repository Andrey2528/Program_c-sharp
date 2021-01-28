using System;
using System.Collections.Generic;

namespace PokerGame
{
	public class GameMain
	{

		public static void Main(string[] args)
		{

			// часть 1 - инициализация переменных
			int extradition = 100;

			for (int a = 0; a < extradition; a++)
			{
				DealCards dc = new DealCards();
				dc.Deal();
			}
			HandEvaluator.DisplayAllToScreen();
		}
	}
}
