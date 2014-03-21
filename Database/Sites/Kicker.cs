using System;
using System.Net;
using HtmlAgilityPack;
using aManager.Resources.Entities;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace aManager
{
	namespace Database
	{
		namespace Sites
		{
			/// <summary>
			/// Description of KickerDe.
			/// </summary>
			public class Kicker : Site
			{
				private string strUsername;
				private string strPassword;
				private bool bLoggedIn = false;
				
				public Boolean LoggedIn
				{
					get { return this.bLoggedIn; }
					private set {}
				}
				
				private Boolean Login(string username, string password)
				{
					Uri oLoginUri = new Uri("http://www.kicker.de/community/login/");
					NameValueCollection oParameters = new NameValueCollection();
					
					oParameters.Add("nickname", this.strUsername);
					oParameters.Add("password", this.strPassword);
					
					this.SendRequest(oLoginUri, WebRequestMethods.Http.Post, oParameters);
					
					if(this.oCookies.Count != 0)
						this.bLoggedIn = true;
					else 
						this.bLoggedIn = false;
					
					return this.bLoggedIn;
				}
				
				public KickerPlayerList GetMyPlayers()
				{
					if(!this.bLoggedIn) return null;
					
					Uri oInteractiveBuli1 = new Uri("http://manager.kicker.de/interactive/bundesliga/meinteam/meinkader/");
					Uri oInteractiveBuli1Day = new Uri("http://manager.kicker.de/interactive/bundesliga/meinteam/spieltagswertung/manid/0/manliga/0/spieltag/X");

					String strResponse = this.SendRequest(oInteractiveBuli1, WebRequestMethods.Http.Get);
					
					HtmlDocument h = new HtmlDocument();
					h.LoadHtml(strResponse);
					
					HtmlNode n = h.DocumentNode.SelectSingleNode("//div[@id='fbmSpielfeldWrapper']/script[3]");
					String s = n.InnerText;
					
					Int32 i = s.IndexOf("{'players'");
					s = s.Substring(i);
					i = s.IndexOf("\";");
					s = s.Substring(0, i);
					
					KickerPlayerList players = Newtonsoft.Json.JsonConvert.DeserializeObject<KickerPlayerList>(s);

					return players;
				}
				
				public Kicker(string username, string password, DbReader reader) : base(reader) 
				{
					this.strUsername = username;
					this.strPassword = password;
					
					this.Login(this.strUsername, this.strPassword);
				}
			}
		}
	}
}
