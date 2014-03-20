using System;

namespace aManager
{
	namespace Resources
	{
		namespace Entities
		{
			/// <summary>
			/// Description of Player.
			/// </summary>
			public class Player
			{
				Team oTeam;
				int iKickerId;
				int iBundesligaId;
				int iTransfermarktId;
				int iKickerPointsTotal;
				int iJerseyNumber;
				string strKickerKey;
				string strRegularPosition;
				string strLastName;
				string strFirstName;
				string strNickName;
				string strAlias;
				
				public int KickerId
				{
					get { return this.iKickerId; }
					private set {}
				}
				
				public int BundesligaId
				{
					get { return this.iBundesligaId; }
					private set {}
				}
				
				public string FirstName
				{
					get { return this.strFirstName; }
					private set {}
				}
				
				public string LastName
				{
					get { return this.strLastName; }
					private set {}
				}
				
				public string NickName
				{
					get { return this.strNickName; }
					private set {}
				}
				
				public string Alias
				{
					get { return this.strAlias; }
					private set {}
				}
				
				public string KickerKey
				{
					get { return this.strKickerKey; }
					private set {}
				}
				
				public int JerseyNumber
				{
					get { return this.iJerseyNumber; }
					private set {}
				}
				
				public int KickerPointsTotal
				{
					get { return this.iKickerPointsTotal; }
					private set {}
				}
				
				public string RegularPosition
				{
					get { return this.strRegularPosition; }
					private set {}
				}
				
				public Team Team
				{
					get { return this.oTeam; }
					private set {}
				}
				
				public void SetKickerPointsTotal(int points)
				{
					this.iKickerPointsTotal = points;
				}
				
				public void SetKickerKey(string key)
				{
					this.strKickerKey = key;
				}
				
				public void SetKickerId(int id)
				{
					this.iKickerId = id;
				}
				
				public void SetTeam(Team team)
				{
					this.oTeam = team;
				}
				
				public Player() {}
				
				public Player(string lastName)
				{
					this.strLastName = lastName;
				}
				
				public Player(int bundesligaId, string firstName, string lastName, string nickName, string alias, int jerseyNumber, string regularPosition)
				{
					this.iBundesligaId = bundesligaId;
					this.strFirstName = firstName;
					this.strLastName = lastName;
					this.strNickName = nickName;
					this.strAlias = alias;
					this.iJerseyNumber = jerseyNumber;
					this.strRegularPosition = regularPosition;
				}
			}
		}
	}
}
