using System;
using Newtonsoft.Json;
using aManager.Resources;
using System.Collections.Generic;

namespace aManager
{
	namespace Resources
	{
		namespace Entities
		{
			public class KickerPlayerList
			{
				[JsonProperty("players")]
				public List<KickerPlayer> Items { get; private set; }
				
				public List<KickerPlayer> GetGoalkeepers()
				{
					return this.GetPlayersOnPosition(KickerPosition.Goalkeeper);
				}
				
				public List<KickerPlayer> GetDefenders()
				{
					return this.GetPlayersOnPosition(KickerPosition.Defense);
				}
				
				public List<KickerPlayer> GetMidfielders()
				{
					return this.GetPlayersOnPosition(KickerPosition.Midfield);
				}
				
				public List<KickerPlayer> GetStrikers()
				{
					return this.GetPlayersOnPosition(KickerPosition.Offense);
				}
			    
			    private List<KickerPlayer> GetPlayersOnPosition(KickerPosition position)
			    {
			    	List<KickerPlayer> l = new List<KickerPlayer>();
			    	
			    	foreach(KickerPlayer p in this.Items)
			    		if(p.Position == position)
			    			l.Add(p);
			    	
					return l;
			    }
			}
		}
	}
}
