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
					set { this.iBuliMatchId = value; }
				}
				
				public int ScoreHome
				{
					get { return this.iScoreHome; }
					set { this.iScoreHome = value; }
				}
				
				public int ScoreAway
				{
					get { return this.iScoreAway; }
					set { this.iScoreAway = value; }
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
					set { this.oTeamHome = value; }
				}
				
				public Team TeamAway
				{
					get { return this.oTeamAway; }
					set { this.oTeamAway = value; }
				}
				
				public DateTime Schedule
				{
					get { return this.oSchedule; }
					set { this.oSchedule = value; }
				}
				
				public void SetScheduleByTimestamp(int timestamp)
				{
					this.oSchedule = this.DateTimeFromTimestamp(timestamp);
				}
				
				public void PushTeam(Team team)
				{
					if(this.oTeamHome == null)
					{
						this.oTeamHome = team;
						return;
					}
					
					if(this.oTeamAway == null)
					{
						this.oTeamAway = team;
						return;
					}
					
					this.oTeamAway = this.oTeamHome;
					this.oTeamHome = team;
				}
				
				public void PushScore(int score)
				{
					if(this.iScoreHome == -1)
					{
						this.iScoreHome = score;
						return;
					}
					
					if(this.iScoreAway == -1)
					{
						this.iScoreAway = score;
						return;
					}
					
					this.iScoreAway = this.iScoreHome;
					this.iScoreHome = score;
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
