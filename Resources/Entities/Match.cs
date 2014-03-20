using System;

namespace aManager
{
	namespace Resources
	{
		namespace Entities
		{
			/// <summary>
			/// Description of Match.
			/// </summary>
			public class Match
			{
				private int iBuliMatchId;
				private int iScoreHome = -1;
				private int iScoreAway = -1;
				private Team oTeamHome;
				private Team oTeamAway;
				private DateTime oSchedule;
				
				public int BundesligaMatchId
				{
					get { return this.iBuliMatchId; }
					private set {}
				}
				
				public int ScoreHome
				{
					get { return this.iScoreHome; }
					private set {}
				}
				
				public int ScoreAway
				{
					get { return this.iScoreAway; }
					private set {}
				}
				
				public string ScoreHomeString
				{
					get 
					{
						if(this.iScoreHome < 0)
							return "-"; 
						else
							return this.iScoreHome.ToString();
					}
					private set {}
				}
				
				public string ScoreAwayString
				{
					get 
					{
						if(this.iScoreAway < 0)
							return "-"; 
						else
							return this.iScoreAway.ToString();
					}
					private set {}
				}
				
				public Team TeamHome
				{
					get { return this.oTeamHome; }
					private set {}
				}
				
				public Team TeamAway
				{
					get { return this.oTeamAway; }
					private set {}
				}
				
				public DateTime Schedule
				{
					get { return this.oSchedule; }
					private set {}
				}
				
				public void SetBundesligaMatchId(int bundesligaMatchId)
				{
					this.iBuliMatchId = bundesligaMatchId;
				}
				
				public void SetScoreHome(int scoreHome)
				{
					this.iScoreHome = scoreHome;
				}
				
				public void SetScoreAway(int scoreAway)
				{
					this.iScoreAway = scoreAway;
				}
				
				public void SetTeamHome(Team teamHome)
				{
					this.oTeamHome = teamHome;
				}
				
				public void SetTeamAway(Team teamAway)
				{
					this.oTeamAway = teamAway;
				}
				
				public void SetSchedule(DateTime schedule)
				{
					this.oSchedule = schedule;
				}
				
				public void SetSchedule(int schedule)
				{
					this.oSchedule = this.DateTimeFromTimestamp(schedule);
				}
				
				public void PushTeam(Team team)
				{
					if(this.oTeamHome == null)
					{
						this.SetTeamHome(team);
						return;
					}
					
					if(this.oTeamAway == null)
					{
						this.SetTeamAway(team);
						return;
					}
					
					this.SetTeamAway(this.oTeamHome);
					this.SetTeamHome(team);
				}
				
				public void PushScore(int score)
				{
					if(this.iScoreHome == -1)
					{
						this.SetScoreHome(score);
						return;
					}
					
					if(this.iScoreAway == -1)
					{
						this.SetScoreAway(score);
						return;
					}
					
					this.SetScoreAway(this.iScoreHome);
					this.SetScoreHome(score);
				}
				
				private DateTime DateTimeFromTimestamp(int timestamp)
				{
				    DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
				    return date.AddSeconds(timestamp).ToLocalTime();
				}
				
				public Match() {}
				public Match(int bundesligaMatchId, DateTime schedule)
				{
					this.iBuliMatchId = bundesligaMatchId;
					this.oSchedule = schedule;
				}
				public Match(int bundesligaMatchId, int schedule)
				{
					this.iBuliMatchId = bundesligaMatchId;
					this.oSchedule = this.DateTimeFromTimestamp(schedule);
				}
				public Match(int bundesligaMatchId, int scoreHome, int scoreAway, Team teamHome, Team teamAway, DateTime schedule)
				{
					this.iBuliMatchId = bundesligaMatchId;
					this.iScoreHome = scoreHome;
					this.iScoreAway = scoreAway;
					this.oTeamHome = teamHome;
					this.oTeamAway = teamAway;
					this.oSchedule = schedule;
				}
				
			}
		}
	}
}
