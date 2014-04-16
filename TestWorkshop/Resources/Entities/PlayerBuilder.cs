using System;
using System.Collections.Generic;
using aManager.Test.Resources.Data;

namespace aManager.Test.Resources.Entities
{
	public class PlayerBuilder
	{
		public Kicker Kicker { get; private set; }
		
		public static PlayerBuilder Player()
		{
			return new PlayerBuilder();
		}
		
		public PlayerBuilder AddKicker(Kicker kickerObject)
		{
			this.Kicker = kickerObject;
			
			return this;
		}
		
		public Player Build()
		{
			Player oPlayer = new Player(this);
			
			return oPlayer;
		}

		private PlayerBuilder() { }
	}
}