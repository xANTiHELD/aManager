using System;
using System.Net;
using HtmlAgilityPack;
using aManager.Resources.Entities;
using aManager.Resources;
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
					
					if(this.Cookies.Count != 0)
						this.bLoggedIn = true;
					else 
						this.bLoggedIn = false;
					
					return this.bLoggedIn;
				}
				
				public KickerFormation? GetFormation()
				{
					if(!this.bLoggedIn) return null;
					
					// TODO: Setup some kind of database containing all relevant Uris
					Uri oInteractiveBuli1 = new Uri("http://manager.kicker.de/interactive/bundesliga/meinteam/meinkader/");
					
					String strResponse = this.SendRequest(oInteractiveBuli1, WebRequestMethods.Http.Get);
					
					HtmlDocument h = new HtmlDocument();
					h.LoadHtml(strResponse);
					
					return this.GetFormation(h);
				}
				
				private KickerFormation GetFormation(HtmlDocument html)
				{
					HtmlNode n = html.DocumentNode.SelectSingleNode("//input[@id='inptactic']");
					
					return (KickerFormation) Convert.ToInt32(n.Attributes["value"].Value);
				}
				
				private void MarkKickerPlayersOnField(KickerPlayerList players, KickerFormation formation)
				{
					// TODO: Will be moved to KickerFormation if changed to class
					int iGoalkeepers = 0;
					int iDefenders = 0;
					int iMidfielders = 0;
					int iStrikers = 0;

					// TODO: Redesign necessary
					switch((int) formation)
					{
						case 0:
							iGoalkeepers = 1;
							iDefenders = 3;
							iMidfielders = 5;
							iStrikers = 2;
							break;
						case 1:
							iGoalkeepers = 1;
							iDefenders = 4;
							iMidfielders = 5;
							iStrikers = 1;
							break;
						case 2:
							iGoalkeepers = 1;
							iDefenders = 4;
							iMidfielders = 4;
							iStrikers = 2;
							break;
						case 3:
							iGoalkeepers = 1;
							iDefenders = 4;
							iMidfielders = 3;
							iStrikers = 3;
							break;
						case 4:
							iGoalkeepers = 1;
							iDefenders = 3;
							iMidfielders = 4;
							iStrikers = 3;
							break;
						default:
							throw new Exception("Something went totally wrong.");
					}
					
					for(int i = 0; i < iGoalkeepers; i++)
						players.GetGoalkeepers()[i].IsOnField = true;
					
					for(int i = 0; i < iDefenders; i++)
						players.GetDefenders()[i].IsOnField = true;
					
					for(int i = 0; i < iMidfielders; i++)
						players.GetMidfielders()[i].IsOnField = true;
					
					for(int i = 0; i < iStrikers; i++)
						players.GetStrikers()[i].IsOnField = true;
					
					return;
				}
				
				public KickerPlayerList GetMyPlayers()
				{
					if(!this.bLoggedIn) return null;
					
					Uri oInteractiveBuli1 = new Uri("http://manager.kicker.de/interactive/bundesliga/meinteam/meinkader/");
					// Uri oInteractiveBuli1Day = new Uri("http://manager.kicker.de/interactive/bundesliga/meinteam/spieltagswertung/manid/0/manliga/0/spieltag/X");

					String strResponse = this.SendRequest(oInteractiveBuli1, WebRequestMethods.Http.Get);
					
					HtmlDocument h = new HtmlDocument();
					h.LoadHtml(strResponse);
					
					HtmlNode n = h.DocumentNode.SelectSingleNode("//div[@id='fbmSpielfeldWrapper']/script[3]");
					String s = n.InnerText;
					
					// TODO: Not nice ^_^
					Int32 i = s.IndexOf("{'players'");
					s = s.Substring(i);
					i = s.IndexOf("\";");
					s = s.Substring(0, i);
					
					KickerPlayerList players = Newtonsoft.Json.JsonConvert.DeserializeObject<KickerPlayerList>(s);
					
					KickerFormation f = this.GetFormation(h);
					
					this.MarkKickerPlayersOnField(players, f);

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
