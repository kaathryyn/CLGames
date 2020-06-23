using System;
using System.Collections.Generic;

namespace CLGames.BlackJack
{
	public class BlackJackHandler
	{

		public BlackJackHandler(Player player)
		{
			Player = player;
			Dealer = new Dealer();
			Deck = new Deck();
			Deck.Shuffle();
		}

		public void InitialiseGame()
		{
			GameIsOngoing = true;
			RunGameCore();
		}

		void RunGameCore()
		{
			Player.MakeBet();

			InitialiseHands();

			if (Player.CalculateValueOfHand() == 21)
			{
				BlackJackConsoleWriter.PlayerGetsBlackJack();
				Player.AddWinnings(Player.CalculateWinnings());
				Player.ViewBalance();
				GameIsOngoing = false;
				RequestNextRound();
			}

			RunGameLoop();
		}
		void InitialiseHands()
		{
			Dealer.InitialiseHand(Deck.GetCards(1));

			Player.InitialiseHand(Deck.GetCards(2));
			Player.ViewHand();
		}

		public void RunGameLoop()
		{
			var move = BlackJackConsoleWriter.RequestMove();

			if (BlackJackInputValidation.IsValidMove(move))
			{
				while (GameIsOngoing)
				{
					switch (move)
					{
						case "1":
							Player.Elbow(GetNewCard());
							Player.ViewHand();

							if (Player.HasBust())
							{
								BlackJackConsoleWriter.PlayerBusts();
								Player.ViewBalance();
								CheckBalance();
							}

							if (Player.Hand.Count == 5)
							{
								BlackJackConsoleWriter.PlayerHas5Cards();
								Player.ReturnDoubleMoney();
								Player.ViewBalance();
								GameIsOngoing = false;
							}

							break;

						case "2":
							Stand();
							break;

						default:
							Player.ViewHand();
							break;
					}

					if (GameIsOngoing)
					{
						move = BlackJackConsoleWriter.RequestMove();
					}
				}
			}
			else
			{
				BlackJackConsoleWriter.InformInvalidChoice();
			}
		}

		public void RequestNextRound()
		{
			BlackJackConsoleWriter.AskToPlayNextRound();
			var response = Console.ReadLine();

			switch (response)
			{
				case "y":
					RefreshHandsAndDeck();
					InitialiseGame();
					break;

				case "n":
					GameIsOngoing = false;
					break;

				default:
					BlackJackConsoleWriter.GreetPlayer(Player.Name);
					break;
			}
		}

		void RefreshHandsAndDeck()
		{
			Player.Hand.Clear();
			Dealer.Hand.Clear();
			Deck = new Deck();
			Deck.Shuffle();
		}

		void Stand()
		{
			Player.ViewHand();
			PresentDealerHand();

			DetermineWinner();
		}

		void PresentDealerHand()
		{
			while (Dealer.CalculateValueOfHand() < 17)
			{
				Dealer.Elbow(GetNewCard());
			}

			Dealer.ViewHand();
		}

		void DetermineWinner()
		{
			if (!Dealer.HasBust())
			{
				if (Player.CalculateValueOfHand() > Dealer.CalculateValueOfHand()
					|| (Player.Hand.Count == 5 && Dealer.CalculateValueOfHand() != 21))
				{
					BlackJackConsoleWriter.PlayerWins();
					Player.ReturnDoubleMoney();
					Player.ViewBalance();
				}
				else if (Player.CalculateValueOfHand() == Dealer.CalculateValueOfHand())
				{
					BlackJackConsoleWriter.PlayerIsReturnedMoney();
					Player.ReturnMoney();
					Player.ViewBalance();
				}
				else
				{
					BlackJackConsoleWriter.PlayerLoses();
					Dealer.AddWinnings(Player.Bet);
					Player.ViewBalance();
				}
			}
			else
			{
				BlackJackConsoleWriter.DealerBust();
				Player.ReturnDoubleMoney();
				Player.ViewBalance();
			}

			GameIsOngoing = false;
			CheckBalance();
		}

		void CheckBalance()
		{
			if (Player.IsBalanceZero())
			{
				GameIsOngoing = false;
				BlackJackConsoleWriter.PlayerHasNoMoney();
			}
			else
			{
				RequestNextRound();
			}
		}

		List<Card> GetNewCard()
		{
			return Deck.GetCards(1);
		}

		private bool GameIsOngoing;

		public Player Player { get; }

		public Dealer Dealer { get; }

		public Deck Deck { get; set; }
	}
}
