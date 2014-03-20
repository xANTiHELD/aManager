using System;
using aManager.Database;
using aManager.Resources.Entities;
using aManager.Database.Sites;

namespace aManager
{
	namespace Test
	{
		class Program
		{
			public static void Main(string[] args)
			{
				Bundesliga bl = new Bundesliga();
				
				foreach(Match m in bl.GetMatches(26))
				{
					Console.WriteLine("{4} {5}\t{0} {1} : {2} {3}", m.TeamHome.Name, m.ScoreHomeString, m.ScoreAwayString, m.TeamAway.Name, m.Schedule.ToShortDateString(), m.Schedule.ToShortTimeString());
				}
				
				Console.WriteLine("Waiting . . .");
				Console.ReadKey(true);
			}
		}
	}
}
