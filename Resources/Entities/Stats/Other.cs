using System;
using System.Collections.Specialized;

namespace aManager
{
	namespace Resources
	{
        namespace Entities.Stats
		{
			/// <summary>
			/// Description of StatsOther.
			/// </summary>
			public class Other
			{
				private int iBallsTouched = -1;
				private int iOffsides = -1;
				private int iCornerKicks = -1;
				private int iFreeKicks = -1;
				private int iThrowIns = -1;
				private int iPunts = -1;
				private int iShotAssists = -1;
				private int iScoreAttemptParticipation = -1;
				private int iMissedChances = -1;
				
				public int BallsTouched
				{
					get { return this.iBallsTouched; }
					set { this.iBallsTouched = value; }
				}
				public int Offsides
				{
					get { return this.iOffsides; }
					set { this.iOffsides = value; }
				}
				
				public int CornerKicks
				{
					get { return this.iCornerKicks; }
					set { this.iCornerKicks = value; }
				}
				
				public int FreeKicks
				{
					get { return this.iFreeKicks; }
					set { this.iFreeKicks = value; }
				}
				
				public int ThrowIns
				{
					get { return this.iThrowIns; }
					set { this.iThrowIns = value; }
				}
				
				public int Punts
				{
					get { return this.iPunts; }
					set { this.iPunts = value; }
				}
				
				public int ShotAssists
				{
					get { return this.iShotAssists; }
					set { this.iShotAssists = value; }
				}
				
				public int ScoreAttemptParticipation
				{
					get { return this.iScoreAttemptParticipation; }
					set { this.iScoreAttemptParticipation = value; }
				}
				
				public int MissedChances
				{
					get { return this.iMissedChances; }
					set { this.iMissedChances = value; }
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
					this.SetAttribute(attributes.Get("imp:balls-touched"), out this.iBallsTouched);
					this.SetAttribute(attributes.Get("offsides"), out this.iOffsides);
					this.SetAttribute(attributes.Get("corner-kicks"), out this.iCornerKicks);
					this.SetAttribute(attributes.Get("imp:freekicks"), out this.iFreeKicks);
					this.SetAttribute(attributes.Get("imp:throw-in"), out this.iThrowIns);
					this.SetAttribute(attributes.Get("imp:punt"), out this.iPunts);
					this.SetAttribute(attributes.Get("imp:shot-assists"), out this.iShotAssists);
					this.SetAttribute(attributes.Get("imp:score-attempts-participation"), out this.iScoreAttemptParticipation);
					this.SetAttribute(attributes.Get("imp:miss-chance"), out this.iMissedChances);
				}
				
				public Other() {}
				
				public Other(NameValueCollection attributes)
				{
					this.SetAttributes(attributes);
				}
			}
		}
	}
}
