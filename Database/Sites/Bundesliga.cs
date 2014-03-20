using System;
using System.IO;
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
			public class Bundesliga
			{
				public List<Match> GetMatches(int matchDay)
				{
					Int32 iSeasonYear = 2013;
					Int32 iMatchDay = matchDay;
					List<Match> oMatches = new List<Match>();
					
					Uri oMatchDayUri = new Uri("http://www.bundesliga.de/de/inc/livebox/liga/" + iSeasonYear + "/" + iMatchDay + ".html");
	
					HttpWebRequest oRequest = null;
					HttpWebResponse oResponse = null;
					
					oRequest = WebRequest.CreateHttp(oMatchDayUri);
					oRequest.Method = WebRequestMethods.Http.Get;
					
					String strResponse = new StreamReader(oRequest.GetResponse().GetResponseStream()).ReadToEnd();
					
					HtmlDocument h = new HtmlDocument();
					h.LoadHtml(strResponse);
					
					HtmlNodeCollection nc = h.DocumentNode.SelectNodes("//ul[@class='clearfix']/li");
					
					DbReader db = new DbReader();
					
					
					foreach(HtmlNode n in nc)
					{
						Match match = new Match(Convert.ToInt32(n.Attributes["data-match"].Value), Convert.ToInt32(n.Attributes["data-start"].Value));
						
						HtmlNodeCollection mc = h.DocumentNode.SelectNodes(n.XPath + "/a[1]/ul[1]/li");
						
						foreach(HtmlNode m in mc)
						{
							Team team = db.GetTeamByBundesligaId(Convert.ToInt32(h.DocumentNode.SelectSingleNode(m.XPath + "/img[1]").Attributes["data-teamid"].Value));
							match.PushTeam(team);
							
							Int32 score;
							if(Int32.TryParse(h.DocumentNode.SelectSingleNode(m.XPath + "/span[1]").InnerText, out score))
								match.PushScore(score);
						}
						
						oMatches.Add(match);
					}
					
					return oMatches;
				}
			}
		}
	}
}
