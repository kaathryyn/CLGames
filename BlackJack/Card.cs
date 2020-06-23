namespace CLGames.BlackJack
{
	public class Card
	{
		public Card(BlackJackCardRank rank, BlackJackCardSuit suit)
		{
			Rank = rank;
			Suit = suit;
		}

		public bool IsPictureCard
		{
			get
			{
				return Rank >= BlackJackCardRank.Jack
					&& Rank <= BlackJackCardRank.King;
			}
		}

		public bool IsAce()
		{
			return Rank.Equals(BlackJackCardRank.Ace);
		}

		public int GetCardValue()
		{
			return IsPictureCard 
				? 10 
				: (int)Rank;
		}

		public override string ToString()
		{
			return Rank.ToString() + " of " + Suit.ToString();
		}

		BlackJackCardRank Rank { get; set; }
		BlackJackCardSuit Suit { get; set; }
	}
}
