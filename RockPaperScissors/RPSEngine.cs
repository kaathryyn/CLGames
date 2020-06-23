using System;
using CLGames.RockPaperScissors;

namespace KathrynsRealPlayground
{
	class RPSEngine : GameEngine
	{
		public RPSEngine()
		{
			RPSConsoleWriter.WriteTitle();
		}

		#region Overrides

		protected override string GetResponseToRestartGame()
		{
			ConsoleWriter.AskPlayAgain();
			return Console.ReadLine();
		}

		protected override void StartGameCore()
		{
			ConsoleSelection = GetConsoleSelection();
			UserSelection = GetUserSelection();

			if (UserSelection == null )
			{
				RPSConsoleWriter.InformInvalidChoice();
				StartGame();
			}

			RunGameLoop();
		}

		#endregion

		#region Implementation

		IRPSMove GetConsoleSelection()
		{
			var randomSelection = new Random().Next(1, 10000) % 3;
			switch (randomSelection)
			{
				case 0:
					return new RockRPSMove();
					
				case 1:
					return new PaperRPSMove();

				case 2:
					return new ScissorsRPSMove();

				default:
					return null;
			}
		}

		void RunGameLoop()
		{
			RPSConsoleWriter.DisplayChosen(UserSelection, ConsoleSelection);
			DetermineWinner(UserSelection, ConsoleSelection);

			TryRestartGame();
		}

		void DetermineWinner(IRPSMove userSelection, IRPSMove consoleSelection)
		{
			var result = userSelection.EvaluateRound(consoleSelection);
			switch (result)
			{
				case RPSResult.Tie:
					RPSConsoleWriter.ShowTieOutput(userSelection, consoleSelection);
					break;

				case RPSResult.Win:
					RPSConsoleWriter.ShowWinOutput(userSelection, consoleSelection);
					break;

				case RPSResult.Lose:
					RPSConsoleWriter.ShowLoseOutput(userSelection, consoleSelection);
					break;
			}
		}

		IRPSMove GetUserSelection()
		{
			Console.WriteLine();
			Console.WriteLine("Choose your weapon: rock, paper, scissors");
			var userInput = Console.ReadLine();

			switch (userInput)
			{
				case "rock":
					return new RockRPSMove();

				case "paper":
					return new PaperRPSMove();

				case "scissors":
					return new ScissorsRPSMove();

				default:
					return null;
			}
		}

		IRPSMove UserSelection { get; set; }
		IRPSMove ConsoleSelection { get; set; }

		#endregion
	}
}
