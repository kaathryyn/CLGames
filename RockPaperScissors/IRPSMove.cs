namespace CLGames
{
	interface IRPSMove
	{
		RPSResult EvaluateRound(IRPSMove opponentsMove);
	}
}
