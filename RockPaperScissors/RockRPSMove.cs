namespace CLGames
{
	class RockRPSMove : IRPSMove
	{
		public RPSResult EvaluateRound(IRPSMove opponentsMove)
		{
			switch (opponentsMove)
			{
				case RockRPSMove _ :
					return RPSResult.Tie;

				case PaperRPSMove _ :
					return RPSResult.Lose;

				case ScissorsRPSMove _ :
					return RPSResult.Win;

				default:
					return RPSResult.Tie;
			}
		}

		public override string ToString()
		{
			return "Rock";
		}
	}
}
