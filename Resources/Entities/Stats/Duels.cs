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
			/// Description of StatsDuels.
			/// </summary>
			public class Duels
			{
				private int iDuelsWon = -1;
				private int iDuelsWonGround = -1;
				private int iDuelsWonHeader = -1;
				private int iDuelsLost = -1;
				private int iDuelsLostGround = -1;
				private int iDuelsLostHeader = -1;
				private double dDuelsWonPercentage = -1;

				public int DuelsWon
				{
					get { return this.iDuelsWon ; }
					set { this.iDuelsWon = value; }
				}
				
				public int DuelsWonGround
				{
					get { return this.iDuelsWonGround ; }
					set { this.iDuelsWonGround = value; }
				}
				
				public int DuelsWonHeader
				{
					get { return this.iDuelsWonHeader ; }
					set { this.iDuelsWonHeader = value; }
				}
				
				public int DuelsLost
				{
					get { return this.iDuelsLost ; }
					set { this.iDuelsLost = value; }
				}
				
				public int DuelsLostGround
				{
					get { return this.iDuelsLostGround ; }
					set { this.iDuelsLostGround = value; }
				}
				
				public int DuelsLostHeader
				{
					get { return this.iDuelsLostHeader ; }
					set { this.iDuelsLostHeader = value; }
				}
				
				public double DuelsWonPercentage
				{
					get { return this.dDuelsWonPercentage ; }
					set { this.dDuelsWonPercentage = value; }
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
					this.SetAttribute(attributes.Get("imp:duels-won"), out this.iDuelsWon);
					this.SetAttribute(attributes.Get("imp:duels-won-ground"), out this.iDuelsWonGround);
					this.SetAttribute(attributes.Get("imp:duels-won-header"), out this.iDuelsWonHeader);
					this.SetAttribute(attributes.Get("imp:duels-lost"), out this.iDuelsLost);
					this.SetAttribute(attributes.Get("imp:duels-lost-ground"), out this.iDuelsLostGround);
					this.SetAttribute(attributes.Get("imp:duels-lost-header"), out this.iDuelsLostHeader);
					this.SetAttribute(attributes.Get("imp:duels-won-percentage"), out this.dDuelsWonPercentage);
				}
				
				public Duels() {}
				
				public Duels(NameValueCollection attributes)
				{
					this.SetAttributes(attributes);
				}
			}
		}
	}
}
