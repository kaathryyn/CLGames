namespace CLGames
{
	class ScissorsRPSMove : IRPSMove
	{
		public RPSResult EvaluateRound(IRPSMove opponentsMove)
		{
			switch (opponentsMove)
			{
				case RockRPSMove _:
					return RPSResult.Lose;

				case PaperRPSMove _:
					return RPSResult.Win;

				case ScissorsRPSMove _:
					return RPSResult.Tie;

				default:
					return RPSResult.Tie;
			}
		}

		public override string ToString()
		{
			return "Scissors";
		}
	}
}
