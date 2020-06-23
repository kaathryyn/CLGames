using System;
using System.IO;

namespace KathrynsRealPlayground
{
	class WordGenerator
	{
		public static string GetWord()
		{
			string[] wordBank = File.ReadAllLines(@"C:\Users\Kathryn.Corpuz\source\repos\KathrynsRealPlayground\KathrynsRealPlayground\WordBank.txt");
			var random = new Random();
			var randomWordIndex = random.Next(wordBank.Length);

			return wordBank[randomWordIndex];
		}
	}
}
