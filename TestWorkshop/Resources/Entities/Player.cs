using System;
using System.Collections.Specialized;
using aManager.Test.Resources.Data;

namespace aManager.Test.Resources.Entities
{
		/// <summary>
		/// Description of Player.
		/// </summary>
		public class Player
		{
			// Concept: Player.Kicker.Id
			// 			Player.Kicker.Stats.Shooting
			//			Player.Team
			//			Player.Name
			//			Player.Bundesliga.Id
			
			public Kicker Kicker { get; private set; }
			
			public Player(PlayerBuilder builder)
			{
				this.Kicker = builder.Kicker;
			}
		}
}
