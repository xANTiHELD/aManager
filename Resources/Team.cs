using System;

namespace aManager
{
	namespace Resources
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
			
			public Team(int managerId, int kickerId, int bundesligaId, int transfermarktId)
			{
				this.iManagerId = managerId;
				this.iKickerId = kickerId;
				this.iBundesligaId = bundesligaId;
				this.iTransfermarktId = transfermarktId;
			}
		}
	}
}
