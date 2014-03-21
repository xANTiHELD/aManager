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
				//int iTransfermarktId;
				int iKickerPointsTotal;
				int iJerseyNumber;
				int iHeight;
				int iWeight;
				string strKickerKey;
				string strRegularPosition;
				string strLastName;
				string strFirstName;
				string strNickName;
				string strAlias;
				string strNationality;
				string strNativeCountry;
				string strBirthplace;
				DateTime oBirthdate;
				Stats oStats;
				
				public int Height
				{
					get { return this.iHeight; }
					set { this.iHeight = value; }
				}
				public int Weight
				{
					get { return this.iWeight; }
					set { this.iWeight = value; }
				}
				public string Nationality
				{
					get { return this.strNationality; }
					set { this.strNationality = value; }
				}
				public string NativeCountry
				{
					get { return this.strNativeCountry; }
					set { this.strNativeCountry = value; }
				}
				public string Birthplace
				{
					get { return this.strBirthplace; }
					set { this.strBirthplace = value; }
				}
				public DateTime Birthdate
				{
					get { return this.oBirthdate; }
					set { this.oBirthdate = value; }
				}
				
				public Stats Stats
				{
					get { return this.oStats; }
					set { this.oStats = value; }
				}
				
				public int KickerId
				{
					get { return this.iKickerId; }
					set { this.iKickerId = value; }
				}
				
				public int BundesligaId
				{
					get { return this.iBundesligaId; }
					set { this.iBundesligaId = value;}
				}
				
				public string FirstName
				{
					get { return this.strFirstName; }
					set { this.strFirstName = value; }
				}
				
				public string LastName
				{
					get { return this.strLastName; }
					set { this.strLastName = value; }
				}
				
				public string NickName
				{
					get { return this.strNickName; }
					set { this.strNickName = value; }
				}
				
				public string Alias
				{
					get { return this.strAlias; }
					set { this.strAlias = value; }
				}
				
				public string KickerKey
				{
					get { return this.strKickerKey; }
					set { this.strKickerKey = value; }
				}
				
				public int JerseyNumber
				{
					get { return this.iJerseyNumber; }
					set { this.iJerseyNumber = value; }
				}
				
				public int KickerPointsTotal
				{
					get { return this.iKickerPointsTotal; }
					set { this.iKickerPointsTotal = value; }
				}
				
				public string RegularPosition
				{
					get { return this.strRegularPosition; }
					set { this.strRegularPosition = value; }
				}
				
				public Team Team
				{
					get { return this.oTeam; }
					set { this.oTeam = value; }
				}
				
				public void SetBirthdateFromTimeString(string timeString)
				{
					int iLength = timeString.ToLower().IndexOf('t');
					timeString = timeString.Substring(0, iLength);

					this.oBirthdate = DateTime.ParseExact(timeString, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
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
