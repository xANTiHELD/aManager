using System;
using System.Net;
using System.Collections.Specialized;

namespace aManager
{
	namespace Database
	{
		namespace Sites
		{
			/// <summary>
			/// Description of Site.
			/// </summary>
			public abstract class Site
			{
				protected CookieContainer oCookies = new CookieContainer();
				protected DbReader oReader = new DbReader();
				
				public CookieContainer Cookies
				{
					get { return this.oCookies; }
					private set {}
				}
				
				public DbReader DbReader
				{
					get { return this.oReader; }
					private set {}
				}
				
				public string SendRequest(Uri uri, string method, NameValueCollection parameters = null)
				{
					HttpWebRequest oRequest = null;
					HttpWebResponse oResponse = null;
					
					if(method == WebRequestMethods.Http.Get)
						uri = new Uri(uri.OriginalString + this.BuildQueryString(parameters, false));
					
					oRequest = WebRequest.CreateHttp(uri);
					oRequest.CookieContainer = this.oCookies;
					oRequest.Method = method;
					oRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:22.0) Gecko/20130405 Firefox/22.0";
					
					if(method == WebRequestMethods.Http.Post)
					{
						Byte[] oData = null;
						oData = System.Text.Encoding.UTF8.GetBytes(this.BuildQueryString(parameters, true));
						oRequest.ContentType = "application/x-www-form-urlencoded";
						oRequest.ContentLength = oData.Length;
						oRequest.GetRequestStream().Write(oData, 0, oData.Length);
					}
					
					oResponse = (HttpWebResponse) oRequest.GetResponse();
					
					return new System.IO.StreamReader(oResponse.GetResponseStream()).ReadToEnd();
				}
				
				public string SendRequest(string uri, string method, NameValueCollection parameters)
				{
					return this.SendRequest(new Uri(uri), method, parameters);
				}
				
				public string BuildQueryString(NameValueCollection parameters, bool post = false)
				{
					String strQueryString = String.Empty;
					
					if(parameters == null || parameters.Count == 0) return strQueryString;
					if(!post) strQueryString = "?";
					
					foreach(String key in parameters)
					{
						strQueryString += WebUtility.UrlEncode(key) + "=" + WebUtility.UrlEncode(parameters[key]) + "&";
					}
					
					strQueryString = strQueryString.Remove(strQueryString.Length - 1);
					
					return strQueryString;
				}
				
				public Site(DbReader reader)
				{
					System.Net.ServicePointManager.Expect100Continue = false;
					this.oReader = reader;
				}
			}
		}
	}
}
