using System;

namespace KathrynsRealPlayground
{
	class GameMenu
	{
		public static void ShowGameMenu()
		{
			ConsoleWriter.DisplayGameMenu();

			var playerInput = Console.ReadLine();
			if (playerInput.ToLower() == "x")
			{
				ConsoleWriter.GameTerminated();
				return;
			}

			var gameEngine = GetGameEngine(playerInput);
			gameEngine?.StartGame();
		}

		static IGameEngine GetGameEngine(string playerInput)
		{
			switch (playerInput)
			{
				case "1":
					return new HangmanEngine();

				case "2":
					return new RPSEngine();

				case "3":
					return new BlackJack.BlackJackEngine();
			}

			return null;
		}
	}
}
