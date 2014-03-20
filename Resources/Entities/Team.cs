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
					private set {}
				}
				
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
				
				public int TranfermarktId
				{
					get { return this.iTransfermarktId; }
					private set {}
				}
				
				public string ManagerKey
				{
					get { return this.strManagerKey; }
					private set {}
				}
				
				public string KickerKey
				{
					get { return this.strKickerKey; }
					private set {}
				}
				
				public string BundesligaKey
				{
					get { return this.strBundesligaKey; }
					private set {}
				}

				public string Name
				{
					get { return this.strName; }
					private set {}
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
