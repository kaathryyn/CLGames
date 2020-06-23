using System;

namespace CLGames.BlackJack
{
	class BlackJackEngine : GameEngine
	{
		public BlackJackEngine()
		{
		}

		protected override string GetResponseToRestartGame()
		{
			ConsoleWriter.AskPlayAgain();
			return Console.ReadLine();
		}

		protected override void StartGameCore()
		{
			BlackJackConsoleWriter.WriteTitle();

			var blackJackHandler = new BlackJackHandler(new Player(GetName()));
			BlackJackConsoleWriter.GreetPlayer(blackJackHandler.Player.Name);
			blackJackHandler.InitialiseGame();

			TryRestartGame();
		}

		public string GetName()
		{
			BlackJackConsoleWriter.AskForName();
			var name = Console.ReadLine();
			return name;
		}
	}
}