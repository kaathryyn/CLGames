using System;

namespace CLGames.BlackJack
{
	public class Player : BasePlayer
	{
		public Player(string name)
			: base(name, 1000000)
		{
		}

		public void MakeBet()
		{
			BlackJackConsoleWriter.AskForBet();
			BlackJackConsoleWriter.ShowBalance(Balance);
			Bet = float.Parse(Console.ReadLine());

			if (Bet <= Balance)
			{
				BlackJackConsoleWriter.ShowBet(Bet);
				BlackJackConsoleWriter.ShowBalance(Balance -= Bet);
			}
			else
			{
				BlackJackConsoleWriter.ShowInsufficientFunds();
				BlackJackConsoleWriter.ShowBalance(Balance);
				MakeBet();
			}
		}

		public float CalculateWinnings()
		{
			var winnings = Bet + (Bet / 2);
			return winnings;
		}

		public void ReturnMoney()
		{
			Balance += Bet;
		}

		public void ReturnDoubleMoney()
		{
			Balance += Bet * 2;
		}

		public void ViewHand()
		{
			BlackJackConsoleWriter.ShowHand(Hand);
			BlackJackConsoleWriter.ShowHandValue(CalculateValueOfHand());
		}

		public bool IsBalanceZero()
		{
			return Balance == 0;
		}

		public override void ViewBalance()
		{
			BlackJackConsoleWriter.ShowBalance(Balance);
		}

		public float Bet { get; set; }
	}
}
