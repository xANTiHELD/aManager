using System;
using System.Net;
using HtmlAgilityPack;
using aManager.Resources.Entities;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace aManager
{
	namespace Database
	{
		namespace Sites
		{
			/// <summary>
			/// Description of BundesligaDe.
			/// </summary>
			public class Bundesliga : Site
			{
				int iSeasonYear = 2013;
				int iLigaId = 51;
				
				public List<Match> GetMatches(int matchDay)
				{
					List<Match> oMatches = new List<Match>();
					
					Uri oMatchDayUri = new Uri("http://www.bundesliga.de/de/inc/livebox/liga/" + this.iSeasonYear + "/" + matchDay + ".html");
					
					String strResponse = this.SendRequest(oMatchDayUri, WebRequestMethods.Http.Get);
					
					HtmlDocument h = new HtmlDocument();
					h.LoadHtml(strResponse);
					
					HtmlNodeCollection nc = h.DocumentNode.SelectNodes("//ul[@class='clearfix']/li");
					
					foreach(HtmlNode n in nc)
					{
						Match match = new Match(Convert.ToInt32(n.Attributes["data-match"].Value), Convert.ToInt32(n.Attributes["data-start"].Value));
						
						HtmlNodeCollection mc = h.DocumentNode.SelectNodes(n.XPath + "/a[1]/ul[1]/li");
						
						foreach(HtmlNode m in mc)
						{
							Team team = this.oReader.GetTeamByBundesligaId(Convert.ToInt32(h.DocumentNode.SelectSingleNode(m.XPath + "/img[1]").Attributes["data-teamid"].Value));
							match.PushTeam(team);
							
							Int32 score;
							if(Int32.TryParse(h.DocumentNode.SelectSingleNode(m.XPath + "/span[1]").InnerText, out score))
								match.PushScore(score);
						}
						
						oMatches.Add(match);
					}
					
					return oMatches;
				}
				
				public Player GetPlayerByReferenceName(string referenceName, int teamId)
				{
					Uri oTeamUri = new Uri("http://www.bundesliga.de/data/feed/" + this.iLigaId + "/" + this.iSeasonYear + "/team_players_dfl/team_players_dfl_" + teamId + ".xml");
					
					String strResponse = this.SendRequest(oTeamUri, WebRequestMethods.Http.Get, this.UselessRandomNumberParameter());
					
					strResponse = strResponse.Replace("../specification/dtd/sportsml-core.dtd", String.Empty);
					
					Player p = this.oReader.GetBundesligaPlayerByReferenceName(referenceName, strResponse);
					
					p.Stats = this.oReader.GetPlayerStatsByBundesligaId(p.BundesligaId, strResponse);
					
					return p;
				}
				
				private NameValueCollection UselessRandomNumberParameter()
				{
					NameValueCollection oParameters = new NameValueCollection();
					oParameters.Add("cb", new Random().Next(10000, 1000000).ToString());
					
					return oParameters;
				}
				
				public Bundesliga(DbReader reader) : base(reader) {}
			}
		}
	}
}
