using System;
using aManager.Database;
using aManager.Resources;

namespace aManager
{
	namespace Test
	{
		class Program
		{
			public static void Main(string[] args)
			{
				Bundesliga bl = new Bundesliga();
				
				bl.GetMatches(25);
				
				Console.WriteLine("Waiting . . .");
				Console.ReadKey(true);
			}
		}
	}
}
