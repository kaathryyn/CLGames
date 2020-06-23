namespace CLGames
{
	static class HangmanInputValidation
	{
		public static bool ValidateInput(string guess)
		{
			if (guess.Length > 1)
			{
				return false;
			}

			if (guess.Length == 0)
			{
				return false;
			}

			return true;
		}
	}
}
