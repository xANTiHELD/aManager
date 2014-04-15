using System;
using System.Net;
using System.Security;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace aManager.Test.Resources.Sites
{
	/// <summary>
	/// Description of Kicker.
	/// </summary>
	public class Kicker : Site
	{
		public bool LoggedIn
		{
			get; private set;
		}
		
		
		
		public bool Login(string username, string password)
		{
			Uri oLoginUri = new Uri("http://www.kicker.de/community/login/");
			NameValueCollection oParameters = new NameValueCollection();
			
			oParameters.Add("nickname", username);
			oParameters.Add("password", password);
			
			SendPostRequest(oLoginUri, this.Cookies, oParameters);
			
			if(this.Cookies.Count != 0)
				this.LoggedIn = true;
			else 
				this.LoggedIn = false;
			
			return this.LoggedIn;
		}
		
		public Kicker() : base()
		{
			this.LoggedIn = false;
		}
	}
}
