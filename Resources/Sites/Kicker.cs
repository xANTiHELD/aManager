using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace aManager
{
	namespace Resources
	{
		namespace Sites
		{
			/// <summary>
			/// Description of KickerDe.
			/// </summary>
			public class Kicker
			{
				private void Init()
				{
					System.Net.ServicePointManager.Expect100Continue = false;
					
					String strUsername = "";
					String strPassword = "";
					Uri oLoginUri = new Uri("http://www.kicker.de/community/login/");
					Uri oInteractiveBuli1 = new Uri("http://manager.kicker.de/interactive/bundesliga/meinteam/meinkader/");
					Uri oInteractiveBuli1Day = new Uri("http://manager.kicker.de/interactive/bundesliga/meinteam/spieltagswertung/manid/0/manliga/0/spieltag/X");
					Byte[] oData = null;
					HttpWebRequest oRequest = null;
					HttpWebResponse oResponse = null;
					CookieContainer oCookies = new CookieContainer();
					NameValueCollection oParameters = new NameValueCollection();
					
					oParameters.Add("nickname", strUsername);
					oParameters.Add("password", strPassword);
		
					oData = Encoding.UTF8.GetBytes(BuildQueryString(oParameters, true));
					
					oRequest = WebRequest.CreateHttp(oLoginUri);
					oRequest.CookieContainer = oCookies;
					oRequest.Method = WebRequestMethods.Http.Post; // Try HEAD
					oRequest.ContentType = "application/x-www-form-urlencoded";
					oRequest.ContentLength = oData.Length;
					
					oRequest.GetRequestStream().Write(oData, 0, oData.Length);
		
					oResponse = (HttpWebResponse) oRequest.GetResponse();
					
					oRequest = WebRequest.CreateHttp(oInteractiveBuli1);
					oRequest.CookieContainer = oCookies;
					oRequest.Method = WebRequestMethods.Http.Get;
					
					String strResponse = new StreamReader(oRequest.GetResponse().GetResponseStream()).ReadToEnd();
				}
					
				private string BuildQueryString(NameValueCollection collection, bool post = false)
				{
					String strQueryString = String.Empty;
					
					if(!post) strQueryString = "?";
					
					if(collection.Count == 0) return strQueryString;
					
					foreach(String key in collection)
					{
						strQueryString += WebUtility.UrlEncode(key) + "=" + WebUtility.UrlEncode(collection[key]) + "&";
					}
					
					strQueryString = strQueryString.Remove(strQueryString.Length - 1);
					
					return strQueryString;
				}
			}
		}
	}
}
