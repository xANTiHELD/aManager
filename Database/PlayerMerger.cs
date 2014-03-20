using System;
using aManager.Database.Sites;
using aManager.Resources.Entities;
using System.Collections.Generic;

namespace aManager
{
	namespace Database
	{
		/// <summary>
		/// Description of PlayerMerger.
		/// </summary>
		public class PlayerMerger
		{
			DbReader oReader;
			Bundesliga oBundesliga;
			
			public List<Player> MergeWithBundesliga(KickerPlayerList kickerList)
			{
				List<Player> managerList = new List<Player>();
				
				foreach(KickerPlayer k in kickerList.Items)
				{
					Team team = this.oReader.GetTeamByKickerId(k.TeamId);
					
					Player p = null;
					
					if(team != null)
						p = this.oBundesliga.GetPlayerByReferenceName(k.LastName, team.BundesligaId);
					else
						p = new Player(k.LastName);
						
					p.SetKickerId(k.Id);
					p.SetKickerKey(k.Key);
					p.SetKickerPointsTotal(k.PointsTotal);
					p.SetTeam(team);

					managerList.Add(p);
				}
				
				return managerList;
			}
			
			public PlayerMerger(DbReader reader, Bundesliga bundesliga)
			{
				this.oReader = reader;
				this.oBundesliga = bundesliga;
			}
		}
	}
}
