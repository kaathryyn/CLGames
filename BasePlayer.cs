using System.Collections.Generic;
using System.Linq;

namespace CLGames.BlackJack
{
	public abstract class BasePlayer
	{
		public BasePlayer(string name, float balance)
		{
			Name = name;
			Balance = balance;
		}

		public string Name { get; }

		public List<Card> Hand => hand ?? (hand = new List<Card>());
		List<Card> hand;

		protected float Balance { get; set; }

		int SumOfHand { get; set; }

		int SumOfHand1 { get; set; }

		public void InitialiseHand(List<Card> startingCards)
		{
			Hand.AddRange(startingCards);
		}

		public void Elbow(List<Card> newCard)
		{
			Hand.AddRange(newCard);
		}

		public int CalculateValueOfHand()
		{
			SumOfHand = 0;
			SumOfHand1 = 0;

			foreach (Card card in Hand)
			{
				if (card.IsAce())
				{
					SumOfHand += 11;
					SumOfHand1 += card.GetCardValue();
				}
				else
				{
					SumOfHand += card.GetCardValue();
					SumOfHand1 += card.GetCardValue();
				}
			}

			if (SumOfHand > 21)
			{
				SumOfHand = SumOfHand1;
			}

			return SumOfHand;
		}

		public bool HasBust()
		{
			return CalculateValueOfHand() > 21;
		}

		public void AddWinnings(float winnings)
		{
			Balance += winnings;
		}

		public void ShowValueOfHand()
		{
			BlackJackConsoleWriter.ShowHandValue(SumOfHand);
		}

		public virtual void ViewBalance()
		{
		}
	}
}