using System;
using System.Xml;
using aManager.Resources.Entities;
using aManager.Resources.Entities.Stats;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace aManager
{
	namespace Database
	{
		/// <summary>
		/// Description of DbReader.
		/// </summary>
		public class DbReader
		{
			public Statistics GetPlayerStatsByBundesligaId(int id, string xml)
			{
				XmlDocument oXml = new XmlDocument();
				oXml.LoadXml(xml);
				NameValueCollection oAttributes = new NameValueCollection();
				
				XmlNode n = oXml.SelectSingleNode("//player-metadata[@player-key='" + id + "']/../player-stats/player-stats-soccer");

				foreach(XmlAttribute x in n.ParentNode.Attributes)
						oAttributes.Add(x.Name, x.Value);
				
				foreach(XmlAttribute x in n.Attributes)
						oAttributes.Add(x.Name, x.Value);
				
				foreach(XmlNode c in n.ChildNodes)
					foreach(XmlAttribute x in c.Attributes)
							oAttributes.Add(x.Name, x.Value);

                Statistics oStats = new Statistics();
				oStats.Foul = new Foul(oAttributes);
				oStats.Goalkeeper = new Goalkeeper(oAttributes);
				oStats.Duels = new Duels(oAttributes);
				oStats.Movement = new Movement(oAttributes);
				oStats.Shooting = new Shooting(oAttributes);
				oStats.Goal = new Goal(oAttributes);
				oStats.Passing = new Passing(oAttributes);
				oStats.Other = new Other(oAttributes);
				
				return oStats;
			}
			
			public Player GetBundesligaPlayerByReferenceName(string referenceName, string xml)
			{
				referenceName = referenceName.ToLower();
				
				XmlDocument oXml = new XmlDocument();
				oXml.LoadXml(xml);
				
				XmlNodeList nl = oXml.SelectNodes("//player-metadata/name");
				XmlNode nodePlayer = null;
				
				foreach(XmlNode n in nl)
				{
					int iProbability = 0;
					
					// TODO: Increase probability
					//		 - ReferenceName found check if SPACE or string termination is behind 
					//		   and/or prior 
					
					if(n.Attributes["last"].Value.ToLower().IndexOf(referenceName) != -1)
						iProbability++;
					
					if(n.Attributes["full"].Value.ToLower().IndexOf(referenceName) != -1)
						iProbability++;
					
					if(n.Attributes["nickname"].Value.ToLower().IndexOf(referenceName) != -1)
						iProbability++;
					
					if(n.Attributes["alias"].Value.ToLower().IndexOf(referenceName) != -1)
						iProbability++;
					
					if(iProbability > 0)
					{
						nodePlayer = n;
						break;
					}
				}
				
				if(nodePlayer == null) 
					return null;
				
				Player p = new Player();
				
				p.BundesligaId = Convert.ToInt32(nodePlayer.ParentNode.Attributes["player-key"].Value);
				p.FirstName = nodePlayer.Attributes["first"].Value;
				p.LastName = nodePlayer.Attributes["last"].Value;
				p.NickName = nodePlayer.Attributes["nickname"].Value;
				p.Alias = nodePlayer.Attributes["alias"].Value;
				p.JerseyNumber = Convert.ToInt32(nodePlayer.ParentNode.Attributes["uniform-number"].Value);
				p.RegularPosition = nodePlayer.ParentNode.Attributes["position-regular"].Value;
				p.Height = Convert.ToInt32(nodePlayer.ParentNode.Attributes["height"].Value);
				p.Weight = Convert.ToInt32(nodePlayer.ParentNode.Attributes["weight"].Value);
				p.Nationality = nodePlayer.ParentNode.Attributes["nationality"].Value;
				p.NativeCountry = nodePlayer.ParentNode.Attributes["imp:native-country"].Value;
				p.Birthplace = nodePlayer.ParentNode.Attributes["birthplace"].Value;
				p.SetBirthdateFromTimeString(nodePlayer.ParentNode.Attributes["date-of-birth"].Value);
				
				return p;
			}
			
			public Team GetTeamByManagerId(int id)
			{
				return this.GetTeamById(id, "id");
			}
			
			public Team GetTeamByKickerId(int id)
			{
				return this.GetTeamById(id, "kicker-id");
			}
			
			public Team GetTeamByBundesligaId(int id)
			{
				return this.GetTeamById(id, "bundesliga-id");
			}
			
			public Team GetTeamByTransfermarktId(int id)
			{
				return this.GetTeamById(id, "transfermarkt-id");
			}
			
			private Team GetTeamById(int id, string idString)
			{
				XmlTextReader oXmlReader = new XmlTextReader(".\\Teams.xml");
				
				while(oXmlReader.Read())
				{
					if(oXmlReader.NodeType == XmlNodeType.Element && oXmlReader.Name == "team")
						if(oXmlReader.GetAttribute(idString) == id.ToString())
						{
							Team team = new Team(Convert.ToInt32(oXmlReader.GetAttribute("id")), 
							                Convert.ToInt32(oXmlReader.GetAttribute("kicker-id")),
			                                Convert.ToInt32(oXmlReader.GetAttribute("bundesliga-id")),
			                                Convert.ToInt32(oXmlReader.GetAttribute("transfermarkt-id")), 
			                                oXmlReader.GetAttribute("key"), 
			                                oXmlReader.GetAttribute("kicker-key"),
			                                oXmlReader.GetAttribute("bundesliga-key"),
			                                oXmlReader.GetAttribute("name"));
							oXmlReader.Close();
							return team;
						}
				}
				
				oXmlReader.Close();
				
				return null;
			}
			
			public DbReader() {}
		}
	}
}