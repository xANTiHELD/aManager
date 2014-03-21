using System;
using System.Collections.Specialized;

namespace aManager
{
	namespace Resources
	{
		namespace Entities
		{
			/// <summary>
			/// Description of StatsShooting.
			/// </summary>
			public class StatsShooting
			{
				private int iShots = -1;
				private int iShotsOnGoal = -1;
				private int iShotsOffPost = -1;
				private int iShotsOutsideBox = -1;
				private int iShotsInsideBox = -1;
				private int iShotsFootInsideBox = -1;
				private int iShotsFootOutsideBox = -1;
				private int iShotsHeader = -1;
				private int iShotsPenalties = -1;
				private int iShotsRightFoot = -1;
				private int iShotsLeftFoot = -1;
				private int iShotsOther = -1;
				
				public int Shots
				{
					get { return this.iShots; }
					set { this.iShots = value; }
				}
				public int ShotsOnGoal
				{
					get { return this.iShotsOnGoal; }
					set { this.iShotsOnGoal = value; }
				}
				public int ShotsOffPost
				{
					get { return this.iShotsOffPost; }
					set { this.iShotsOffPost = value; }
				}
				public int ShotsOutsideBox
				{
					get { return this.iShotsOutsideBox; }
					set { this.iShotsOutsideBox = value; }
				}
				public int ShotsInsideBox
				{
					get { return this.iShotsInsideBox; }
					set { this.iShotsInsideBox = value; }
				}
				public int ShotsFootInsideBox
				{
					get { return this.iShotsFootInsideBox; }
					set { this.iShotsFootInsideBox = value; }
				}
				public int ShotsFootOutsideBox
				{
					get { return this.iShotsFootOutsideBox; }
					set { this.iShotsFootOutsideBox = value; }
				}
				public int ShotsHeader
				{
					get { return this.iShotsHeader; }
					set { this.iShotsHeader = value; }
				}
				public int ShotsPenalties
				{
					get { return this.iShotsPenalties; }
					set { this.iShotsPenalties = value; }
				}
				public int ShotsRightFoot
				{
					get { return this.iShotsRightFoot; }
					set { this.iShotsRightFoot = value; }
				}
				public int ShotsLeftFoot
				{
					get { return this.iShotsLeftFoot; }
					set { this.iShotsLeftFoot = value; }
				}
				public int ShotsOther
				{
					get { return this.iShotsOther; }
					set { this.iShotsOther = value; }
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
				
				public void SetAttributes(NameValueCollection attributes)
				{
					this.SetAttribute(attributes.Get("shots-total"), out this.iShots);
					this.SetAttribute(attributes.Get("shots-on-goal-total"), out this.iShotsOnGoal);
					this.SetAttribute(attributes.Get("imp:shots-off-post"), out this.iShotsOffPost);
					this.SetAttribute(attributes.Get("imp:shots-total-outside-box"), out this.iShotsOutsideBox);
					this.SetAttribute(attributes.Get("imp:shots-total-inside-box"), out this.iShotsInsideBox);
					this.SetAttribute(attributes.Get("imp:shots-foot-inside-box"), out this.iShotsFootInsideBox);
					this.SetAttribute(attributes.Get("imp:shots-foot-outside-box"), out this.iShotsFootOutsideBox);
					this.SetAttribute(attributes.Get("imp:shots-right-leg"), out this.iShotsRightFoot);
					this.SetAttribute(attributes.Get("imp:shots-left-leg"), out this.iShotsLeftFoot);
					this.SetAttribute(attributes.Get("imp:shots-other"), out this.iShotsOther);
					
					if(!this.SetAttribute(attributes.Get("imp:shots-total-header"), out this.iShotsHeader))
						this.SetAttribute(attributes.Get("imp:shots-head"), out this.iShotsHeader);
					
					if(!this.SetAttribute(attributes.Get("shots-penalty-shot-taken"), out this.iShotsPenalties))
						if(Int32.TryParse(attributes.Get("shots-penalty-shot-scored"), out this.iShotsPenalties))
						{
							int i = this.iShotsPenalties;
							if(Int32.TryParse(attributes.Get("shots-penalty-shot-missed"), out this.iShotsPenalties))
								this.iShotsPenalties += i;
							else
								this.iShotsPenalties = -1;
						}
						else
							this.iShotsPenalties = -1;
				}
				
				public StatsShooting() {}
				
				public StatsShooting(NameValueCollection attributes)
				{
					this.SetAttributes(attributes);
				}
			}
		}
	}
}
