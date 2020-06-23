using System;

namespace CLGames
{
	class RPSConsoleWriter : ConsoleWriter
	{
		public static void WriteTitle()
		{
			Console.WriteLine(@"
 _____            _      _____                     
| __  | ___  ___ | |_   |  _  | ___  ___  ___  ___ 
|    -|| . ||  _|| '_|  |   __|| .'|| . || -_||  _|
|__|__||___||___||_,_|  |__|   |__,||  _||___||_|  
                                    |_|            
                                                   
     _____       _                                 
    |   __| ___ |_| ___  ___  ___  ___  ___        
    |__   ||  _|| ||_ -||_ -|| . ||  _||_ -|       
    |_____||___||_||___||___||___||_|  |___|       
                                            ");
		}

		public static string RequestInput()
		{
			Console.WriteLine();
			Console.WriteLine("Choose your weapon: rock, paper, scissors");
			return Console.ReadLine();
		}

		public static void InformInvalidChoice()
		{
			Console.WriteLine("Please select either rock, paper or scissors");
		} 

		public static void DisplayChosen(IRPSMove userSelection, IRPSMove consoleSelection)
		{
			Console.WriteLine("You chose: " + userSelection);
			Console.WriteLine("Console chose: " + consoleSelection);
			Console.WriteLine();
		}

		public static void ShowTieOutput(IRPSMove userSelection, IRPSMove consoleSelection)
		{
			Console.WriteLine($"{userSelection} ties with {consoleSelection}.");
		}

		public static void ShowWinOutput(IRPSMove userSelection, IRPSMove consoleSelection)
		{
			Console.WriteLine($"{userSelection} beats {consoleSelection}! You WIN :)");
		}

		public static void ShowLoseOutput(IRPSMove userSelection, IRPSMove consoleSelection)
		{
			Console.WriteLine($"{userSelection} loses to {consoleSelection}. You LOSE :(");
		}
	}
}
