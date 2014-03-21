using System;
using System.Collections.Specialized;
using System.Globalization;

namespace aManager
{
	namespace Resources
	{
		namespace Entities
		{
			/// <summary>
			/// Description of StatsGoalkeeper.
			/// </summary>
			public class StatsGoalkeeper
			{
				private int iSaves = -1;
				private int iGoalsAgainst = -1;
				private int iInterceptedCrosses = -1;
				private int iInterceptedCorners = -1;
				private int iPenaltySaves = -1;
				private int iExtraordinarySaves = -1;
				private int iPreventedClearCutChances = -1;
				private double dSavePercentage = -1;
				private int iShutouts = -1;
				private int iPuntsCompleted = -1;
				private int iThrowsCompleted = -1;
				
				public int Saves
				{
					get { return this.iSaves ; }
					set { this.iSaves = value; }
				}
				
				public int GoalsAgainst
				{
					get { return this.iGoalsAgainst ; }
					set { this.iGoalsAgainst = value; }
				}
				
				public int InterceptedCrosses
				{
					get { return this.iInterceptedCrosses ; }
					set { this.iInterceptedCrosses = value; }
				}
				
				public int InterceptedCorners
				{
					get { return this.iInterceptedCorners ; }
					set { this.iInterceptedCorners = value; }
				}
				
				public int PenaltySaves
				{
					get { return this.iPenaltySaves ; }
					set { this.iPenaltySaves = value; }
				}
				
				public int ExtraordinarySaves
				{
					get { return this.iExtraordinarySaves ; }
					set { this.iExtraordinarySaves = value; }
				}
				
				public int PreventedClearCutChances
				{
					get { return this.iPreventedClearCutChances ; }
					set { this.iPreventedClearCutChances = value; }
				}
				
				public double SavePercentage
				{
					get { return this.dSavePercentage ; }
					set { this.dSavePercentage = value; }
				}
				
				public int Shutouts
				{
					get { return this.iShutouts ; }
					set { this.iShutouts = value; }
				}
				
				public int PuntsCompleted
				{
					get { return this.iPuntsCompleted ; }
					set { this.iPuntsCompleted = value; }
				}
				
				public int ThrowsCompleted
				{
					get { return this.iThrowsCompleted ; }
					set { this.iThrowsCompleted = value; }
				}
				
				private bool SetAttribute(string value, out int key)
				{
					if(!Int32.TryParse(value, out key))
					{
						key = -1;
						return false;
					}

					return true;
				}
				
				private bool SetAttribute(string value, out double key)
				{
					if(!Double.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("en-US"), out key))
					{
						key = -1;
						return false;
					}

					return true;
				}
				
				public void SetAttributes(NameValueCollection attributes)
				{
					this.SetAttribute(attributes.Get("saves"), out this.iSaves);
					this.SetAttribute(attributes.Get("goals-against-total"), out this.iGoalsAgainst);
					this.SetAttribute(attributes.Get("imp:catches-punches-crosses"), out this.iInterceptedCrosses);
					this.SetAttribute(attributes.Get("imp:catches-punches-corners"), out this.iInterceptedCorners);
					this.SetAttribute(attributes.Get("imp:saves-extraordinary"), out this.iExtraordinarySaves);
					this.SetAttribute(attributes.Get("imp:clear-cut-chance"), out this.iPreventedClearCutChances);
					this.SetAttribute(attributes.Get("save-percentage"), out this.dSavePercentage);
					this.SetAttribute(attributes.Get("shutouts"), out this.iShutouts);
					this.SetAttribute(attributes.Get("imp:punt-completed"), out this.iPuntsCompleted);
					this.SetAttribute(attributes.Get("imp:throw-completed"), out this.iThrowsCompleted);
					
					if(!this.SetAttribute(attributes.Get("imp:penalty-saves"), out this.iPenaltySaves))
						this.SetAttribute(attributes.Get("imp:saves-penalty-shot"), out this.iPenaltySaves);
				}
				
				public StatsGoalkeeper() {}
				
				public StatsGoalkeeper(NameValueCollection attributes)
				{
					this.SetAttributes(attributes);
				}
			}
		}
	}
}
