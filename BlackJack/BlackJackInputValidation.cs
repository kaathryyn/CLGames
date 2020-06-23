using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLGames.BlackJack
{
	static class BlackJackInputValidation
	{
		public static bool IsValidMove(string move)
		{
			return !move.Equals("1") || !move.Equals("2");
		}

		public static bool IsValidResponseToNextRound(string response)
		{
			return !response.Equals("y") || !response.Equals("n");
		}

		public static bool IsValidBet(string bet)
		{
			float floatValue = 0;
			return float.TryParse(bet, out floatValue);
		}
	}
}
