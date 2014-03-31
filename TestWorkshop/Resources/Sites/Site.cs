using System;
using System.Net;
using System.Collections.Specialized;

namespace aManager.Test.Resources.Sites
{
	/// <summary>
	/// Description of Site.
	/// </summary>
	public abstract partial class Site
	{
		public CookieContainer Cookies { get; private set; }
		
		public static string SendRequest(Uri uri, string method)
		{
			return SendRequest(uri, method, null, null);
		}
		
		public static string SendRequest(Uri uri, string method, CookieContainer cookies)
		{
			return SendRequest(uri, method, cookies, null);
		}
		
		public static string SendRequest(Uri uri, string method, NameValueCollection parameters)
		{
			return SendRequest(uri, method, null, parameters);
		}
		
		public static string SendRequest(Uri uri, string method, CookieContainer cookies, NameValueCollection parameters)
		{
			HttpWebRequest oRequest = null;
			HttpWebResponse oResponse = null;
			
			if(parameters != null && method == WebRequestMethods.Http.Get)
				uri = new Uri(uri.OriginalString + BuildQueryString(parameters, false));
			
			oRequest = WebRequest.CreateHttp(uri);
			oRequest.CookieContainer = cookies;
			oRequest.Method = method;
			oRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:22.0) Gecko/20130405 Firefox/22.0";
			
			if(method == WebRequestMethods.Http.Post)
			{
				Byte[] oData = null;
				oData = System.Text.Encoding.UTF8.GetBytes(BuildQueryString(parameters, true));
				oRequest.ContentType = "application/x-www-form-urlencoded";
				oRequest.ContentLength = oData.Length;
				oRequest.GetRequestStream().Write(oData, 0, oData.Length);
			}
			
			oResponse = (HttpWebResponse) oRequest.GetResponse();
			
			return new System.IO.StreamReader(oResponse.GetResponseStream()).ReadToEnd();
		}
		
		public static string BuildQueryString(NameValueCollection parameters, bool post = false)
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
		
		protected Site()
		{
			System.Net.ServicePointManager.Expect100Continue = false;
					
			this.Cookies = new CookieContainer();
		}
	}
}
