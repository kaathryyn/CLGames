namespace CLGames.BlackJack
{
	public class Dealer : BasePlayer
	{
		public Dealer() 
			: base("Carlos", 5000000)
		{
		}

		public void ViewHand()
		{
			BlackJackConsoleWriter.ShowDealersHand(Hand);
			BlackJackConsoleWriter.ShowHandValue(CalculateValueOfHand());
		}

		public override void ViewBalance()
		{
			BlackJackConsoleWriter.ShowDealersBalance(Balance);
		}
	}
}
