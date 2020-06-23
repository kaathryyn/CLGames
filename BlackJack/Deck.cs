using System;
using System.Collections.Generic;
using System.Linq;

namespace CLGames.BlackJack
{
	public class Deck
	{
		public Deck()
		{
			Cards = CreateNewDeck().ToList();
		}

		public IEnumerable<Card> CreateNewDeck()
		{
			foreach (BlackJackCardSuit suit in Enum.GetValues(typeof(BlackJackCardSuit)))
			{
				foreach (BlackJackCardRank rank in Enum.GetValues(typeof(BlackJackCardRank)))
				{
					yield return new Card(rank, suit);
				}
			}
		}

		public void Shuffle()
		{
			var random = new Random();
			for (var i = 0; i < Cards.Count; i++)
			{
				var randomIndex = random.Next(Cards.Count());

				(Cards[i], Cards[randomIndex]) = (Cards[randomIndex], Cards[i]);
			}
		}

		public List<Card> GetCards(int numberOfCards)
		{
			var takenCards = Cards
				.Take(numberOfCards)
				.ToList();

			Cards.RemoveAll(takenCards.Contains);

			return takenCards;
		}

		public override string ToString()
		{
			var listOfCardStrings = Cards.Select(card => card.ToString()).ToArray();
			return string.Join(", ", listOfCardStrings);
		}

		List<Card> Cards { get; set; }
	}
}
