using System;
using System.Collections.Specialized;
using System.Globalization;

namespace aManager
{
	namespace Resources
	{
        namespace Entities.Stats
		{
			/// <summary>
			/// Description of StatsMovement.
			/// </summary>
			public class Movement
			{
				private double dDistance = -1;
				private double dAverageSpeed = -1;
				private double dMaxSpeed = -1;
				private int iSprints = -1;
				private double dSprintsDistance = -1;
				private int iFastRuns = -1;
				private double dFastRunsDistance = -1;
				
				public double Distance
				{
					get { return this.dDistance; }
					set { this.dDistance = value; }
				}
				public double AverageSpeed
				{
					get { return this.dAverageSpeed; }
					set { this.dAverageSpeed = value; }
				}
				public double MaxSpeed
				{
					get { return this.dMaxSpeed; }
					set { this.dMaxSpeed = value; }
				}
				public int Sprints
				{
					get { return this.iSprints; }
					set { this.iSprints = value; }
				}
				public double SprintsDistance
				{
					get { return this.dSprintsDistance; }
					set { this.dSprintsDistance = value; }
				}
				public int FastRuns
				{
					get { return this.iFastRuns; }
					set { this.iFastRuns = value; }
				}
				public double FastRunsDistance
				{
					get { return this.dFastRunsDistance; }
					set { this.dFastRunsDistance = value; }
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
					this.SetAttribute(attributes.Get("imp:tracking-distance"), out this.dDistance);
					this.SetAttribute(attributes.Get("imp:tracking-average-speed"), out this.dAverageSpeed);
					this.SetAttribute(attributes.Get("imp:tracking-max-speed"), out this.dMaxSpeed);
					this.SetAttribute(attributes.Get("imp:tracking-sprints"), out this.iSprints);
					this.SetAttribute(attributes.Get("imp:tracking-sprints-distance"), out this.dSprintsDistance);
					this.SetAttribute(attributes.Get("imp:tracking-fast-runs"), out this.iFastRuns);
					this.SetAttribute(attributes.Get("imp:tracking-fast-runs-distance"), out this.dFastRunsDistance);
				}
				
				public Movement() {}
				
				public Movement(NameValueCollection attributes)
				{
					this.SetAttributes(attributes);
				}
			}
		}
	}
}
