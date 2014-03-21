using System;
using System.Collections.Specialized;

namespace aManager
{
	namespace Resources
	{
		namespace Entities
		{
			/// <summary>
			/// Description of StatsFoul.
			/// </summary>
			public class StatsFoul
			{
				private int iFoulsCommited = -1;
				private int iFoulsSuffered = -1;
				private int iYellowCards = -1;
				private int iYellowRedCards = -1;
				private int iRedCards = -1;
				
				public int FoulsCommited
				{
					get { return iFoulsCommited; }
					set { this.iFoulsCommited = value; }
				}
				
				public int FoulsSuffered
				{
					get { return iFoulsSuffered; }
					set { this.iFoulsSuffered = value; }
				}
				
				public int YellowCards
				{
					get { return iYellowCards; }
					set { this.iYellowCards = value; }
				}
				
				public int YellowRedCards
				{
					get { return iYellowRedCards; }
					set { this.iYellowRedCards = value; }
				}
				
				public int RedCards
				{
					get { return iRedCards; }
					set { this.iRedCards = value; }
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
					this.SetAttribute(attributes.Get("fouls-commited"), out this.iFoulsCommited);
					this.SetAttribute(attributes.Get("fouls-suffered"), out this.iFoulsSuffered);
					this.SetAttribute(attributes.Get("imp:yellow-cards"), out this.iYellowCards);
					
					if(!this.SetAttribute(attributes.Get("imp:red-card-ejections"), out this.iRedCards))
					   this.SetAttribute(attributes.Get("imp:red-cards"), out this.iRedCards);
					
					if(!this.SetAttribute(attributes.Get("imp:yellow-red-card-ejections"), out this.iYellowRedCards))
					   this.SetAttribute(attributes.Get("imp:yellow-red-cards"), out this.iYellowRedCards);
				}
				
				public StatsFoul() {}
				
				public StatsFoul(NameValueCollection attributes)
				{
					this.SetAttributes(attributes);
				}
			}
		}
	}
}
