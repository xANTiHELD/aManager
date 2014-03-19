using System;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace aManager
{
	namespace Resources
	{
		/// <summary>
		/// Description of BundesligaDe.
		/// </summary>
		public class Bundesliga
		{
			public void GetMatches(int matchDay)
			{
				Int32 iSeasonYear = 2013;
				Int32 iMatchDay = matchDay;
				
				Uri oMatchDayUri = new Uri("http://www.bundesliga.de/de/inc/livebox/liga/" + iSeasonYear + "/" + iMatchDay + ".html");

				HttpWebRequest oRequest = null;
				HttpWebResponse oResponse = null;
				
				oRequest = WebRequest.CreateHttp(oMatchDayUri);
				oRequest.Method = WebRequestMethods.Http.Get;
				
				String strResponse = new StreamReader(oRequest.GetResponse().GetResponseStream()).ReadToEnd();
				
				HtmlDocument h = new HtmlDocument();
				h.LoadHtml(strResponse);
				
				HtmlNodeCollection nc = h.DocumentNode.SelectNodes("//ul[@class='clearfix']/li");
				
				foreach(HtmlNode n in nc)
				{
					Console.WriteLine(n.Attributes["data-match"].Value);
					
					HtmlNodeCollection mc = h.DocumentNode.SelectNodes(n.XPath + "/a[1]/ul[1]/li");
					
					foreach(HtmlNode m in mc)
					{
						Console.Write(h.DocumentNode.SelectSingleNode(m.XPath + "/img[1]").Attributes["data-teamid"].Value);
						Console.WriteLine(": " + h.DocumentNode.SelectSingleNode(m.XPath + "/span[1]").InnerText);
					}
				}
				
				return;
			}
		}
	}
}
