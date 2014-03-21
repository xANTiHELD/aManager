using System;

namespace aManager
{
	namespace Resources
	{
		namespace Entities
		{
			/// <summary>
			/// Description of Team.
			/// </summary>
			public class Team
			{
				private int iManagerId;
				private int iKickerId;
				private int iBundesligaId;
				private int iTransfermarktId;
				private string strName;
				private string strManagerKey;
				private string strKickerKey;
				private string strBundesligaKey;
				
				public int ManagerId
				{
					get { return this.iManagerId; }
					set { this.iManagerId = value; }
				}
				
				public int KickerId
				{
					get { return this.iKickerId; }
					set { this.iKickerId = value; }
				}
				
				public int BundesligaId
				{
					get { return this.iBundesligaId; }
					set { this.iBundesligaId = value; }
				}
				
				public int TranfermarktId
				{
					get { return this.iTransfermarktId; }
					set { this.iTransfermarktId = value; }
				}
				
				public string ManagerKey
				{
					get { return this.strManagerKey; }
					set { this.strManagerKey = value; }
				}
				
				public string KickerKey
				{
					get { return this.strKickerKey; }
					set { this.strKickerKey = value; }
				}
				
				public string BundesligaKey
				{
					get { return this.strBundesligaKey; }
					set { this.strBundesligaKey = value; }
				}

				public string Name
				{
					get { return this.strName; }
					set { this.strName = value; }
				}
				
				public Team(int managerId, int kickerId, int bundesligaId, int transfermarktId, string managerKey, string kickerKey, string bundesligaKey, string name)
				{
					this.iManagerId = managerId;
					this.iKickerId = kickerId;
					this.iBundesligaId = bundesligaId;
					this.iTransfermarktId = transfermarktId;
					this.strManagerKey = managerKey;
					this.strKickerKey = kickerKey;
					this.strBundesligaKey = bundesligaKey;
					this.strName = name;
				}
			}
		}
	}
}
