using System;

namespace aManager.Test.Resources.Data
{
	public class Kicker
	{
		public int Id { get; private set; }
		public int MarketValue { get; private set; }
		public int Points { get; private set; }
		public int TeamId { get; private set; }
		public bool Uefa { get; private set; }
		public string Name { get; private set; }
		public int Position { get; private set; }
		public string PictureUrl { get; private set; }
		public string Key { get; private set; }
		public string TeamKey { get; private set; }
		
		public Kicker() { }
	}
}