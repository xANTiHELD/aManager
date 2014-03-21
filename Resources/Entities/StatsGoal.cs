using System;
using System.Collections.Specialized;

namespace aManager
{
	namespace Resources
	{
		namespace Entities
		{
			/// <summary>
			/// Description of StatsGoal.
			/// </summary>
			public class StatsGoal
			{
				private int iScore = -1;
				private int iAssists = -1;
				private int iScorePenalty = -1;
				private int iScoreRightFoot = -1;
				private int iScoreLeftFoot = -1;
				private int iScoreHeader = -1;
				private int iScoreOther = -1;
				private int iOwnGoal = -1;
				
				public int Score
				{
					get { return this.iScore; }
					set { this.iScore = value; }
				}
				
				public int Assists
				{
					get { return this.iAssists; }
					set { this.iAssists = value; }
				}
				
				public int ScorePenalty
				{
					get { return this.iScorePenalty; }
					set { this.iScorePenalty = value; }
				}
				
				public int ScoreRightFoot
				{
					get { return this.iScoreRightFoot; }
					set { this.iScoreRightFoot = value; }
				}
				
				public int ScoreLeftFoot
				{
					get { return this.iScoreLeftFoot; }
					set { this.iScoreLeftFoot = value; }
				}
				
				public int ScoreHeader
				{
					get { return this.iScoreHeader; }
					set { this.iScoreHeader = value; }
				}
				
				public int ScoreOther
				{
					get { return this.iScoreOther; }
					set { this.iScoreOther = value; }
				}
				
				public int OwnGoal
				{
					get { return this.iOwnGoal; }
					set { this.iOwnGoal = value; }
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
					this.SetAttribute(attributes.Get("score"), out this.iScore);
					this.SetAttribute(attributes.Get("assists-total"), out this.iAssists);
					this.SetAttribute(attributes.Get("shots-penalty-shot-scored"), out this.iScorePenalty);
					this.SetAttribute(attributes.Get("imp:goals-right-leg"), out this.iScoreRightFoot);
					this.SetAttribute(attributes.Get("imp:goals-left-leg"), out this.iScoreLeftFoot);
					this.SetAttribute(attributes.Get("imp:goals-head"), out this.iScoreHeader);
					this.SetAttribute(attributes.Get("imp:goals-other"), out this.iScoreOther);
					this.SetAttribute(attributes.Get("imp:own-goal"), out this.iOwnGoal);
				}
				
				public StatsGoal() {}
				
				public StatsGoal(NameValueCollection attributes)
				{
					this.SetAttributes(attributes);
				}
			}
		}
	}
}
