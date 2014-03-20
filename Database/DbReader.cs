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
			XmlReader oXmlReader;
			
			public Team GetTeamByManagerId(int id)
			{
				
				return null;
				
			}
			
			public Team GetTeamByKickerId(int id)
			{
				
				return null;
				
			}
			
			public Team GetTeamByBundesligaId(int id)
			{
				this.Init();
				
				while(oXmlReader.Read())
				{
					if(oXmlReader.NodeType == XmlNodeType.Element && oXmlReader.Name == "team")
						if(oXmlReader.GetAttribute("bundesliga-id") == id.ToString())
							return new Team(Convert.ToInt32(oXmlReader.GetAttribute("id")), 
							                Convert.ToInt32(oXmlReader.GetAttribute("kicker-id")),
			                                Convert.ToInt32(oXmlReader.GetAttribute("bundesliga-id")),
			                                Convert.ToInt32(oXmlReader.GetAttribute("transfermarkt-id")), 
			                                oXmlReader.GetAttribute("key"), 
			                                oXmlReader.GetAttribute("kicker-key"),
			                                oXmlReader.GetAttribute("bundesliga-key"),
			                                oXmlReader.GetAttribute("name"));
				}
				
				return null;
			}
			
			public Team GetTeamByTransfermarktId(int id)
			{
				
				return null;
				
			}
			
			private void Init()
			{
				this.oXmlReader = new XmlTextReader(".\\Teams.xml");
			}
			
			public DbReader()
			{
				this.Init();
			}
		}
	}
}