using aManager.Test.Resources.Sites;
using System;
using System.Runtime.InteropServices;

namespace aManager.Test
{
	class Program
	{
		public static void Main(string[] args)
		{
			Kicker k = new Kicker();
			
			Console.Write("Kicker.de Account\nUsername: ");
			String strUsr = Console.ReadLine();
			Console.Write("Password: ");
			//String strPwd = String.Empty;
			System.Security.SecureString strPwd = new System.Security.SecureString();
			
			ConsoleKeyInfo c = Console.ReadKey(true);
			
			while(c.Key != ConsoleKey.Enter)
			{
				if(c.Key != ConsoleKey.Backspace)
				{
					Console.Write("*");
					strPwd.AppendChar(c.KeyChar);
				}
				else if(strPwd.Length > 0)
				{
					strPwd.RemoveAt(strPwd.Length - 1);
						
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Console.Write(" ");
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				
				c = Console.ReadKey(true);
			}
			
			strPwd.MakeReadOnly();
			
		    IntPtr ptrString = Marshal.SecureStringToGlobalAllocUnicode(strPwd);
		    string s = Marshal.PtrToStringUni(ptrString);
			Console.WriteLine("\nLoggedIn: {0}", k.Login(strUsr, Marshal.PtrToStringUni(ptrString)));
		    Marshal.ZeroFreeGlobalAllocUnicode(ptrString);
			
			Console.WriteLine("\nWaiting . . .");
			Console.ReadKey(true);
		}
	}
}
