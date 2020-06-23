using System;
using System.Collections.Generic;
using System.Linq;

namespace CLGames
{
	public class HangmanEngine : GameEngine
	{
		public HangmanEngine()
		{
			GameIsOngoing = true;
		}

		#region Overrides

		protected override void RefreshAllValues()
		{
			GameIsOngoing = true;
			Guesses.Clear();
			NumberOfWrongGuesses = 0;
			WordToGuess = string.Empty;
		}

		protected override string GetResponseToRestartGame()
		{
			ConsoleWriter.AskPlayAgain();
			return Console.ReadLine();
		}

		protected override void StartGameCore()
		{
			HangmanConsoleWriter.WriteTitle();
			GenerateWordToGuess();

			while (GameIsOngoing)
			{
				RunGameLoop();
			}

			TryRestartGame();
		}

		#endregion

		#region Implementation

		void RunGameLoop()
		{
			HangmanConsoleWriter.PrintGuesses(Guesses);

			GenerateTiles();
			var guess = HangmanConsoleWriter.RequestInput();

			if (HangmanInputValidation.ValidateInput(guess))
			{
				var guessCharacter = guess[0];
				Guesses.Add(guessCharacter);

				if (!WordToGuess.Contains(guessCharacter))
				{
					NumberOfWrongGuesses++;
				}
				else
				{
					if (HaveWeWonYet())
					{
						GameIsOngoing = false;

						HangmanConsoleWriter.WinnerOutput(WordToGuess);
						return;
					}
				}
			}
			else
			{
				HangmanConsoleWriter.InvalidGuess();
			}

			DrawHangman();

			CheckNumberOfWrongGuesses();
		}

		bool HaveWeWonYet()
		{
			var wordAsList = WordToGuess.ToList();
			wordAsList.RemoveAll(c => Guesses.Contains(c));

			return wordAsList.Count == 0;
		}

		void GenerateWordToGuess()
		{
			WordToGuess = WordGenerator.GetWord();
		}

		void GenerateTiles()
		{
			foreach (var character in WordToGuess)
			{
				if (Guesses.Contains(character))
				{
					Console.Write(character + " ");
				}
				else
				{
					Console.Write("_ ");
				}
			}
		}

		void DrawHangman()
		{
			HangmanConsoleWriter.DrawHangman(NumberOfWrongGuesses);
		}

		void CheckNumberOfWrongGuesses()
		{
			if (NumberOfWrongGuesses >= 12)
			{
				GameIsOngoing = false;

				HangmanConsoleWriter.LoserOutput(WordToGuess);
			}
		}

		#region Properties

		bool GameIsOngoing { get; set; }

		int NumberOfWrongGuesses { get; set; }

		string WordToGuess { get; set; }

		string Response { get; set; }

		List<char> Guesses => guesses ?? (guesses = new List<char>());
		List<char> guesses;

		#endregion

		#endregion
	}
}
