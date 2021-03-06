﻿using System;
using System.Data;
using System.Net;
using System.Collections.Generic;
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
				DbReader db = new DbReader();
				Bundesliga bl = new Bundesliga(db);

				Console.Write("Kicker.de Account\nUsername: ");
				String strUsr = Console.ReadLine();
				Console.Write("Password: ");
				String strPwd = String.Empty;
				
				char c = Console.ReadKey(true).KeyChar;
				
				while((int) c != 13)
				{
					Console.Write("*");
					strPwd += c.ToString();
					c = Console.ReadKey(true).KeyChar;
				}
				
				Console.WriteLine("\n\nLoading . . .");
				
				Kicker k = new Kicker(strUsr, strPwd, db);
				
				if(!k.LoggedIn)
				{
					Console.WriteLine("Could not login. Wrong credentials?");
					Console.ReadKey(true);
					return;
				}
				
				PlayerMerger pm = new PlayerMerger(db, bl);
				
				List<Player> pl = pm.MergeWithBundesliga(k.GetMyPlayers());
				
				Console.Write("\nMatchday: ");
				int i = Convert.ToInt32(Console.ReadLine());
				List<Match> ml = bl.GetMatches(i);
				
				Console.WriteLine();
				
				foreach(Match m in ml)
				{
					int iHomeInterest = 0;
					int iAwayInterest = 0;
					
					foreach(Player p in pl)
					{
						if(p.Team == null)
							continue;
						
						if(p.Team.ManagerId == m.TeamHome.ManagerId)
							iHomeInterest++;
						
						if(p.Team.ManagerId == m.TeamAway.ManagerId)
							iAwayInterest++;
					}
					
					Console.Write("{0} - {1}", m.Schedule.ToShortDateString(), m.Schedule.ToShortTimeString());
					
					switch(iHomeInterest)
					{
						case 1:
							Console.ForegroundColor = ConsoleColor.DarkRed;
							break;
						case 2: 
							Console.ForegroundColor = ConsoleColor.Red;
							break;
						case 3:
						case 4:
							Console.ForegroundColor = ConsoleColor.Magenta;
							break;
						default:
							Console.ForegroundColor = ConsoleColor.Gray;
							break;
					}
					
					Console.Write(" {0}", m.TeamHome.Name);
					Console.ForegroundColor = ConsoleColor.Gray;
					
					Console.Write(" {0} : {1} ", m.ScoreHomeString, m.ScoreAwayString);
					
					switch(iAwayInterest)
					{
						case 1:
							Console.ForegroundColor = ConsoleColor.DarkRed;
							break;
						case 2: 
							Console.ForegroundColor = ConsoleColor.Red;
							break;
						case 3:
						case 4:
							Console.ForegroundColor = ConsoleColor.Magenta;
							break;
						default:
							Console.ForegroundColor = ConsoleColor.Gray;
							break;
					}
					
					Console.WriteLine("{0}", m.TeamAway.Name);
					Console.ForegroundColor = ConsoleColor.Gray;
				}
				
				Console.WriteLine("\nYour team (on field)\nName Goals/Assists");
				
				foreach(Player p in pl)
					if(p.KickerIsOnField)
					{
						if(p.Alias != String.Empty)
							Console.Write(p.Alias);
						else 
							Console.Write(p.LastName);
						
						Console.WriteLine(" {0}/{1}", p.Stats.Goal.Score, p.Stats.Goal.Assists);
					}
						
				
				Console.WriteLine("\nWaiting . . .");
				Console.ReadKey(true);
			}
		}
	}
}
