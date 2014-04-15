using System;
using Newtonsoft.Json;

namespace aManager.Test.Resources.Entities
{
	public partial class Player
	{
		public class Kicker
		{
			[JsonProperty("splid")]
			public int Id { get; private set; }
			
			public Kicker() { }
		}
	}
}