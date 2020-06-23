namespace CLGames
{
	class PaperRPSMove : IRPSMove
	{
		public RPSResult EvaluateRound(IRPSMove opponentsMove)
		{
			switch (opponentsMove)
			{
				case RockRPSMove _:
					return RPSResult.Win;

				case PaperRPSMove _:
					return RPSResult.Tie;

				case ScissorsRPSMove _:
					return RPSResult.Lose;

				default:
					return RPSResult.Tie;
			}
		}

		public override string ToString()
		{
			return "Paper";
		}
	}
}
