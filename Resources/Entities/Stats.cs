using System;
using aManager.Resources.Entities;

namespace aManager
{
	namespace Resources
	{
		namespace Entities
		{
			/// <summary>
			/// Description of Stats.
			/// </summary>
			public class Stats
			{
				private StatsFoul oFoul = null;
				private StatsGoalkeeper oGoalkeeper = null;
				private StatsPassing oPassing = null;
				private StatsShooting oShooting = null;
				private StatsDuels oDuels = null;
				private StatsGoal oGoal = null;
				private StatsMovement oMovement = null;
				private StatsOther oOther = null;
				
				public StatsFoul Foul
				{
					get { return this.oFoul; }
					set { this.oFoul = value; }
				}
				
				public StatsGoalkeeper Goalkeeper
				{
					get { return this.oGoalkeeper; }
					set { this.oGoalkeeper = value; }
				}
				
				public StatsPassing Passing
				{
					get { return this.oPassing; }
					set { this.oPassing = value; }
				}
				
				public StatsShooting Shooting
				{
					get { return this.oShooting; }
					set { this.oShooting = value; }
				}
				
				public StatsDuels Duels
				{
					get { return this.oDuels; }
					set { this.oDuels = value; }
				}
				
				public StatsGoal Goal
				{
					get { return this.oGoal; }
					set { this.oGoal = value; }
				}
				
				public StatsMovement Movement
				{
					get { return this.oMovement; }
					set { this.oMovement = value; }
				}
				
				public StatsOther Other
				{
					get { return this.oOther; }
					set { this.oOther = value; }
				}
				
				public Stats() {}
			}
		}
	}
}
