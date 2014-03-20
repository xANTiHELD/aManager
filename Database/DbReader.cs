using System;
using System.Xml;
using aManager.Resources.Entities;
using System.Collections.Generic;

namespace aManager
{
	namespace Database
	{
		/// <summary>
		/// Description of DbReader.
		/// </summary>
		public class DbReader
		{
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
				
				Player p = new Player(Convert.ToInt32(nodePlayer.ParentNode.Attributes["player-key"].Value),
				                      nodePlayer.Attributes["first"].Value, 
				                      nodePlayer.Attributes["last"].Value,
				                      nodePlayer.Attributes["nickname"].Value, 
				                      nodePlayer.Attributes["alias"].Value, 
				                      Convert.ToInt32(nodePlayer.ParentNode.Attributes["uniform-number"].Value), 
				                      nodePlayer.ParentNode.Attributes["position-regular"].Value);

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