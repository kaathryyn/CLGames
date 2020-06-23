using System;
using System.Collections.Generic;

namespace CLGames
{
	class HangmanConsoleWriter : ConsoleWriter
	{
		public static void WriteTitle()
		{
			Console.WriteLine(@"
 _                                             
| |                                            
| |__   __ _ _ __   __ _ _ __ ___   __ _ _ __  
| '_ \ / _` | '_ \ / _` | '_ ` _ \ / _` | '_ \ 
| | | | (_| | | | | (_| | | | | | | (_| | | | |
|_| |_|\__,_|_| |_|\__, |_| |_| |_|\__,_|_| |_|
                    __/ |                      
                   |___/                       ");
		}

		public static string RequestInput()
		{
			Console.WriteLine();
			Console.Write("Please guess the next character: ");
			return Console.ReadLine();
		}

		public static void PrintGuesses(List<char> Guesses)
		{
			Console.WriteLine("Current guesses: {0}", string.Join(",", Guesses));
		}


		public static void WinnerOutput(string WordToGuess)
		{
			Console.WriteLine("YAY YOU WON! The word was: {0}", WordToGuess);
			Console.WriteLine(@"    
 _ _ _  _                     
| | | ||_| ___  ___  ___  ___ 
| | | || ||   ||   || -_||  _|
|_____||_||_|_||_|_||___||_|  
                              
       .-=========-.
       \'-=======-'/
       _|   .=.   |_
      ((|  {{1}}  |))
       \|   /|\   |/
        \__ '`' __/
          _`) (`_
        _/_______\_
       /___________\");
		}

		public static void LoserOutput(string WordToGuess)
		{
			Console.WriteLine("YOU LOSE SUCKA! The word was: {0}", WordToGuess);
			Console.WriteLine(@"
        _                     
       | |                    
       | | ___  ___  ___ _ __ 
       | |/ _ \/ __|/ _ \ '__|
       | | (_) \__ \  __/ |   
       |_|\___/|___/\___|_|   

              _______
             |/      |
             |      (_)
             |      \|/
             |       |
             |      / \
             |
            _|___");
		}



		public static void InvalidGuess()
		{
			Console.WriteLine("Please enter only one character fool!");
		}

		#region Hangman Ascii

		public static void DrawHangman(int numberOfWrongGuesses)
		{
			if (numberOfWrongGuesses > 0)
			{
				Console.WriteLine(GetHangmanArt(numberOfWrongGuesses));
			}
		}

		static string GetHangmanArt(int numberOfWrongGuesses)
		{
			switch (numberOfWrongGuesses)
			{
				case 1:
					return HangmanArtOne;

				case 2:
					return HangmanArtTwo;

				case 3:
					return HangmanArtThree;

				case 4:
					return HangmanArtFour;

				case 5:
					return HangmanArtFive;

				case 6:
					return HangmanArtSix;

				case 7:
					return HangmanArtSeven;

				case 8:
					return HangmanArtEight;

				case 9:
					return HangmanArtNine;

				case 10:
					return HangmanArtTen;

				case 11:
					return HangmanArtEleven;

				default:
					return string.Empty;
			}
		}

		const string HangmanArtOne = @"
  |
  |
  |
  |
  |
  |
  |";

		const string HangmanArtTwo = @"
  |
  |
  |
  |
  |
  |
 _|___";

		const string HangmanArtThree = @"
   _______
  |
  |
  |
  |
  |
  |
 _|___";

		const string HangmanArtFour = @"
   _______
  |/
  |
  |
  |
  |
  |
 _|___";

		const string HangmanArtFive = @"
   _______
  |/      |
  |
  |
  |
  |
  |
 _|___";

		const string HangmanArtSix = @"
   _______
  |/      |
  |      (_)
  |
  |
  |
  |
 _|___";

		const string HangmanArtSeven = @"
   _______
  |/      |
  |      (_)
  |       |
  |
  |
  |
 _|___";

		const string HangmanArtEight = @"
   _______
  |/      |
  |      (_)
  |      \|
  |       
  |
  |
 _|___";

		const string HangmanArtNine = @"
   _______
  |/      |
  |      (_)
  |      \|/
  |       
  |      
  |
 _|___";

		const string HangmanArtTen = @"
   _______
  |/      |
  |      (_)
  |      \|/
  |       |
  |      
  |
 _|___";

		const string HangmanArtEleven = @"
   _______
  |/      |
  |      (_)
  |      \|/
  |       |
  |      /
  |
 _|___";

		#endregion
	}
}
