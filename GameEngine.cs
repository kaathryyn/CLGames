namespace KathrynsRealPlayground
{
	public abstract class GameEngine : IGameEngine
	{
		public void StartGame()
		{
			StartGameCore();
		}

		protected void TryRestartGame()
		{
			var response = GetResponseToRestartGame();

			switch (response.ToLower())
			{
				case "y":
					RefreshAllValues();
					StartGame();
					break;

				case "n":
					GameMenu.ShowGameMenu();
					break;

				default:
					ConsoleWriter.InformInvalidPlayAgainReponse();
					TryRestartGame();
					break;
			}
		}

		protected abstract string GetResponseToRestartGame();

		protected abstract void StartGameCore();

		protected virtual void RefreshAllValues()
		{
		}
	}
}
