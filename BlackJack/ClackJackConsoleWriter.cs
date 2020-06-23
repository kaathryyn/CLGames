using System;
using System.Collections.Generic;

namespace CLGames.BlackJack
{
	class BlackJackConsoleWriter
	{
		public static void WriteTitle()
		{
			Console.WriteLine(@"
 _____  _            _         __            _   
| __  || | ___  ___ | |_    __|  | ___  ___ | |_ 
| __ -|| || .'||  _|| '_|  |  |  || .'||  _|| '_|
|_____||_||__,||___||_,_|  |_____||__,||___||_,_|
");
		}

		public static void AskForName()
		{
			Console.WriteLine("Hola. What is your name?");
		}

		public static void GreetPlayer(string name)
		{
			Console.WriteLine();
			Console.WriteLine("G'Day " + name + "! Let's play some BlackJack.");
		}

		public static void DealingCardsMessage()
		{
			Console.WriteLine("Dealing out the cards.....");
			Console.WriteLine(@"
 _____         _____
|A .  | _____ |A _  |
| /.\ ||A ^  || ( ) |
|(_._)|| / \ ||(_ _)|
|  |  || \ / ||  |  |
|____V||  .  ||_____|
       |____V|       ");
		}

		public static void ShowHand(List<Card> cards)
		{
			Console.WriteLine();
			Console.Write("Your Hand: ");
			Console.Write(string.Join<Card>(", ", cards));
			Console.WriteLine();
		}

		public static void ShowDealersHand(List<Card> dealersCards)
		{
			Console.Write("Dealer's hand: ");
			Console.Write(string.Join<Card>(", ", dealersCards));
			Console.WriteLine();
		}

		public static void ShowHandValue(int sum)
		{
			Console.WriteLine("Sum of Cards: " + sum);
		}

		public static string RequestMove()
		{
			Console.WriteLine(@"
Choose your move:
1: Elbow
2: Stand");
			return Console.ReadLine();
		}

		public static void InformInvalidChoice()
		{
			Console.WriteLine("Please select either to Elbow or Stand");
		}

		public static void ShowBalance(float balance)
		{
			Console.WriteLine("Current Balance: $" + balance);
		}

		public static void ShowDealersBalance(float dealersBalance)
		{
			Console.WriteLine("Dealer's Balance: $" + dealersBalance);
		}

		public static void AskForBet()
		{
			Console.WriteLine();
			Console.WriteLine("How much would you like to bet?");
		}

		public static void ShowBet(float bet)
		{
			Console.WriteLine("You bet: $" + bet);
		}

		public static void ShowInsufficientFunds()
		{
			Console.WriteLine("Sorry mate. You have insufficient funds.");
		}

		#region Results
		public static void DealerBust()
		{
			Console.WriteLine("The dealer has BUST! You win 2x your money!");
		}

		public static void PlayerGetsBlackJack()
		{
			Console.WriteLine();
			Console.WriteLine("You got a BLACKJACK! You win 1.5x your money!");
		}

		public static void PlayerHas5Cards()
		{
			Console.WriteLine();
			Console.WriteLine("You got a 5 card Samuel! You win 2x your money!");
		}

		public static void PlayerWins()
		{
			Console.WriteLine("You win 2x you money!");
		}

		public static void PlayerIsReturnedMoney()
		{
			Console.WriteLine("You have the same value as the dealer! Here's your mullah back.");
		}

		public static void PlayerBusts()
		{
			Console.WriteLine("You bust, you LOSE, SUCKER!");
		}

		public static void PlayerLoses()
		{
			Console.WriteLine("The dealer's hand beats yours. You lose, SUCKER!");
		}

		#endregion

		public static void PlayerHasNoMoney()
		{
			Console.WriteLine("Soz, bro! You're broke! Better luck next time.");
		}

		public static void AskToPlayNextRound()
		{
			Console.WriteLine("Do you want to continue playing? (y/n)");
		}
	}
}