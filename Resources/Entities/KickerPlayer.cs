using System;
using Newtonsoft.Json;

namespace aManager
{
	namespace Resources
	{	
		namespace Entities
		{
			/// <summary>
			/// Description of KickerPlayer.
			/// </summary>
			public class KickerPlayer
			{
				private int iPointsTotal;
				private bool bIsOnField = false;
				
				public bool IsOnField
				{
					get { return this.bIsOnField; }
					set { this.bIsOnField = value; }
				}
				
				[JsonProperty("splid")]
			    public int Id { get; private set; }
			    
			    //[JsonProperty("wert")]
			    //public int MarketValue { get; private set; }
			    
			    // TODO: Distinguish between points earned in season and points earned for
			    //		 your team only!
			    [JsonProperty("pkt")]
			    private string _PointsTotal 
			    { 
			    	get { return this.iPointsTotal.ToString(); }
			    	set { this.iPointsTotal = this.NormalizePoints(value); }
			    }
			    
			    public int PointsTotal
			    {
			    	get { return this.iPointsTotal; }
			    	private set {}
			    }
			    
			    [JsonProperty("vrnid")]
			    public int TeamId { get; private set; }
			    
			    //[JsonProperty("vrn")]
			    //public string KickerTeamName { get; private set; }
			    
			    //[JsonProperty("uefa")]
			    //public int KickerPlayerIsUefa { get; private set; }
			    
			    [JsonProperty("spl")]
			    public string LastName { get; private set; }

			    [JsonProperty("pos")]
			    public KickerPosition Position { get; private set; }
			    
			    //[JsonProperty("bild")]
			    //public string Image { get; private set; }
			    
			    [JsonProperty("splf")]
			    public string Key { get; private set; }
			    
			    //[JsonProperty("vrnf")]
			    //public string TeamKey { get; private set; }
			    
			    private int NormalizePoints(string pointsTotal)
			    {
			    	String normalized = String.Empty;
			    	
			    	foreach(char c in pointsTotal.ToCharArray())
			    	{
			    		if(Char.IsDigit(c))
			    			normalized += c.ToString();
			    	}
			    	
			    	return Convert.ToInt32(normalized);
			    }
			}
		}
	}
}
