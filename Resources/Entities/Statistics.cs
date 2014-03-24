using System;
using aManager.Resources.Entities.Stats;

namespace aManager
{
	namespace Resources
	{
		namespace Entities
		{
			/// <summary>
			/// Description of Stats.
			/// </summary>
			public class Statistics
			{
				private Foul oFoul = null;
				private Goalkeeper oGoalkeeper = null;
				private Passing oPassing = null;
				private Shooting oShooting = null;
				private Duels oDuels = null;
				private Goal oGoal = null;
				private Movement oMovement = null;
				private Other oOther = null;
				
				public Foul Foul
				{
					get { return this.oFoul; }
					set { this.oFoul = value; }
				}
				
				public Goalkeeper Goalkeeper
				{
					get { return this.oGoalkeeper; }
					set { this.oGoalkeeper = value; }
				}
				
				public Passing Passing
				{
					get { return this.oPassing; }
					set { this.oPassing = value; }
				}
				
				public Shooting Shooting
				{
					get { return this.oShooting; }
					set { this.oShooting = value; }
				}
				
				public Duels Duels
				{
					get { return this.oDuels; }
					set { this.oDuels = value; }
				}
				
				public Goal Goal
				{
					get { return this.oGoal; }
					set { this.oGoal = value; }
				}
				
				public Movement Movement
				{
					get { return this.oMovement; }
					set { this.oMovement = value; }
				}
				
				public Other Other
				{
					get { return this.oOther; }
					set { this.oOther = value; }
				}
				
				public Statistics() {}
			}
		}
	}
}
