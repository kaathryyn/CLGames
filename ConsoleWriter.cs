using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KathrynsRealPlayground
{
	class ConsoleWriter
	{
		public static void AskPlayAgain()
		{
			Console.WriteLine();
			Console.WriteLine("Do you want to play a new game? (y/n)");
		}

		public static void InformInvalidPlayAgainReponse()
		{
			Console.WriteLine("Please enter either 'y' or 'n'");
		}

		public static void DisplayGameMenu()
		{
			Console.Clear();
			Console.WriteLine(@"
-------------------------------------------------
 _____                     _____                
|   __| ___  _____  ___   |     | ___  ___  _ _ 
|  |  || .'||     || -_|  | | | || -_||   || | |
|_____||__,||_|_|_||___|  |_|_|_||___||_|_||___|

-------------------------------------------------
");
			Console.WriteLine(@"Please select the game you want to play
1: Hangman
2: Rock Paper Scissors
3: Blackjack

x: Exit");
		}

		public static void GameTerminated()
		{
			Console.WriteLine(@"                                                                                               
              _____                  
             |   __| ___  _____  ___ 
             |  |  || .'||     || -_|
             |_____||__,||_|_|_||___|                                              
 _____                  _            _           _ 
|_   _|___  ___  _____ |_| ___  ___ | |_  ___  _| |
  | | | -_||  _||     || ||   || .'||  _|| -_|| . |
  |_| |___||_|  |_|_|_||_||_|_||__,||_|  |___||___|
");
		}
	}
}
