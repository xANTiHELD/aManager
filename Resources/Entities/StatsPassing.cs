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
			/// Description of StatsPassing.
			/// </summary>
			public class StatsPassing
			{
				private int iPasses = -1;
				private int iPassesCompleted = -1;
				private int iPassesFailed = -1;
				private double dPassesCompletedPercentage = -1;
				private double dPassesFailedPercentage = -1;
				private int iCrosses = -1;
				private int iCrossesCompleted = -1;
				private int iPassesShort = -1;

				public int Passes
				{
					get { return this.iPasses; }
					set { this.iPasses = value; }
				}
				
				public int PassesCompleted
				{
					get { return this.iPassesCompleted; }
					set { this.iPassesCompleted = value; }
				}
				
				public int PassesFailed
				{
					get { return this.iPassesFailed; }
					set { this.iPassesFailed = value; }
				}
				
				public double PassesCompletedPercentage
				{
					get { return this.dPassesCompletedPercentage; }
					set { this.dPassesCompletedPercentage = value; }
				}
				
				public double PassesFailedPercentage
				{
					get { return this.dPassesFailedPercentage; }
					set { this.dPassesFailedPercentage = value; }
				}
				
				public int Crosses
				{
					get { return this.iCrosses; }
					set { this.iCrosses = value; }
				}
				
				public int CrossesCompleted
				{
					get { return this.iCrossesCompleted; }
					set { this.iCrossesCompleted = value; }
				}
				
				public int PassesShort
				{
					get { return this.iPassesShort; }
					set { this.iPassesShort = value; }
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
					this.SetAttribute(attributes.Get("imp:passes"), out this.iPasses);
					this.SetAttribute(attributes.Get("imp:passes-completed"), out this.iPassesCompleted);
					this.SetAttribute(attributes.Get("imp:passes-failed"), out this.iPassesFailed);
					this.SetAttribute(attributes.Get("imp:passes-completions-percentage"), out this.dPassesCompletedPercentage);
					this.SetAttribute(attributes.Get("imp:passes-failed-percentage"), out this.dPassesFailedPercentage);
					this.SetAttribute(attributes.Get("imp:crosses"), out this.iCrosses);
					this.SetAttribute(attributes.Get("imp:crosses-completed"), out this.iCrossesCompleted);
					this.SetAttribute(attributes.Get("imp:passes-short-total"), out this.iPassesShort);
				}
				
				public StatsPassing() {}
				
				public StatsPassing(NameValueCollection attributes)
				{
					this.SetAttributes(attributes);
				}
			}
		}
	}
}
