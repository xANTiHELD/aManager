using aManager.Test.Resources.Sites;
using aManager.Test.Resources.Entities;
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
		    
		    String ovTeamPlayerElements = "{'players':[{'splid':'22067','wert':'2400','pkt':'PG: <b>181</b>','vrnid':'81','vrn':'Nürnberg','uefa':'1','spl':'Schäfer','pos':'1','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/22067_81_2013711114759383.jpg','splf':'raphael-schaefer','vrnf':'1-fc-nuernberg-81'},{'splid':'48633','wert':'800','pkt':'PG: <b>-3</b>','vrnid':'81','vrn':'Nürnberg','uefa':'1','spl':'Rakovsky','pos':'1','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/48633_81_2013711114840778.jpg','splf':'patrick-rakovsky','vrnf':'1-fc-nuernberg-81'},{'splid':'65598','wert':'200','pkt':'PG: <b>0</b>','vrnid':'4','vrn':'Bremen','uefa':'1','spl':'Strebinger','pos':'1','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/65598_4_201389145459755.jpg','splf':'strebinger-richard','vrnf':'werder-bremen-4'},{'splid':'29616','wert':'300','pkt':'PG: <b>1</b>','vrnid':'91','vrn':'Augsburg','uefa':'1','spl':'Reinhardt','pos':'2','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/29616_91_20137111148737.jpg','splf':'dominik-reinhardt','vrnf':'fc-augsburg-91'},{'splid':'67127','wert':'200','pkt':'PG: <b>9</b>','vrnid':'3209','vrn':'Hoffenheim','uefa':'1','spl':'Toljan','pos':'2','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/67127_3209_201371294122319.jpg','splf':'toljan-jeremy','vrnf':'1899-hoffenheim-3209'},{'splid':'67281','wert':'1400','pkt':'PG: <b>9</b>','vrnid':'41','vrn':'Braunschweig','uefa':'1','spl':'Elabdellaoui','pos':'2','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/67281_41_201378164715707.jpg','splf':'elabdellaoui-omar','vrnf':'eintracht-braunschweig-41'},{'splid':'45198','wert':'800','pkt':'PG: <b>-1</b>','vrnid':'30','vrn':'Mainz','uefa':'1','spl':'Koch','pos':'2','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/45198_30_201375151724226.jpg','splf':'julian-koch','vrnf':'1-fsv-mainz-05-30'},{'splid':'65515','wert':'200','pkt':'PG: <b>0</b>','vrnid':'2874','vrn':'Elazig','uefa':'1','spl':'Gökdemir','pos':'2','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/65515_58_20137129412182.jpg','splf':'goekdemir-ali','vrnf':'elazigspor'},{'splid':'22714','wert':'2800','pkt':'PG: <b>92</b>','vrnid':'15','vrn':'Gladbach','uefa':'1','spl':'Stranzl','pos':'2','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/22714_15_201371111480163.jpg','splf':'martin-stranzl','vrnf':'borussia-mgladbach-15'},{'splid':'39686','wert':'8500','pkt':'PG: <b>175</b>','vrnid':'14','vrn':'Bayern','uefa':'1','spl':'Ribery','pos':'3','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/39686_14_2013719183210539.jpg','splf':'franck-ribery','vrnf':'bayern-muenchen-14'},{'splid':'50433','wert':'1000','pkt':'PG: <b>146</b>','vrnid':'91','vrn':'Augsburg','uefa':'1','spl':'Hahn','pos':'3','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/50433_91_2013711114844248.jpg','splf':'andre-hahn','vrnf':'fc-augsburg-91'},{'splid':'59516','wert':'4500','pkt':'PG: <b>20</b>','vrnid':'24','vrn':'Wolfsburg','uefa':'1','spl':'de Bruyne','pos':'3','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/59516_24_2014221115844758.jpg','splf':'de-bruyne-kevin','vrnf':'vfl-wolfsburg-24'},{'splid':'44484','wert':'4200','pkt':'PG: <b>191</b>','vrnid':'15','vrn':'Gladbach','uefa':'0','spl':'Raffael','pos':'3','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/44484_15_2013711114835888.jpg','splf':'raffael','vrnf':'borussia-mgladbach-15'},{'splid':'46429','wert':'8500','pkt':'PG: <b>221</b>','vrnid':'17','vrn':'Dortmund','uefa':'1','spl':'Reus','pos':'3','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/46429_17_2013711114837768.jpg','splf':'marco-reus','vrnf':'borussia-dortmund-17'},{'splid':'57238','wert':'200','pkt':'PG: <b>6</b>','vrnid':'4','vrn':'Bremen','uefa':'1','spl':'Aycicek','pos':'3','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/57238_4_201389145458855.jpg','splf':'aycicek-levent','vrnf':'werder-bremen-4'},{'splid':'79036','wert':'400','pkt':'PG: <b>0</b>','vrnid':'15','vrn':'Gladbach','uefa':'1','spl':'Dahoud','pos':'3','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/79036_15_2013724155358991.jpg','splf':'dahoud-mahmoud','vrnf':'borussia-mgladbach-15'},{'splid':'75831','wert':'200','pkt':'PG: <b>0</b>','vrnid':'12','vrn':'HSV','uefa':'1','spl':'Nafiu','pos':'3','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/75831_12_201388202924120.jpg','splf':'naifu-valmir','vrnf':'hamburger-sv-12'},{'splid':'67074','wert':'400','pkt':'PG: <b>53</b>','vrnid':'11','vrn':'Stuttgart','uefa':'1','spl':'Werner','pos':'4','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/67074_11_2013924144850132.jpg','splf':'werner-timo','vrnf':'vfb-stuttgart-11'},{'splid':'41678','wert':'4500','pkt':'PG: <b>155</b>','vrnid':'15','vrn':'Gladbach','uefa':'1','spl':'Kruse','pos':'4','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/41678_15_2013711114829398.jpg','splf':'max-kruse','vrnf':'borussia-mgladbach-15'},{'splid':'67727','wert':'200','pkt':'PG: <b>0</b>','vrnid':'91','vrn':'Augsburg','uefa':'1','spl':'Ekin','pos':'4','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/67727_91_20137111149678.jpg','splf':'ekin-arif','vrnf':'fc-augsburg-91'},{'splid':'72475','wert':'200','pkt':'PG: <b>-1</b>','vrnid':'3209','vrn':'Hoffenheim','uefa':'1','spl':'Karaman','pos':'4','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/72475_3209_201371294125232.jpg','splf':'karaman-kenan','vrnf':'1899-hoffenheim-3209'},{'splid':'40965','wert':'200','pkt':'PG: <b>0</b>','vrnid':'91','vrn':'Augsburg','uefa':'1','spl':'Nebihi','pos':'4','bild':'http://mediadb.kicker.de/2014/fussball/spieler/s/40965_91_201371111482878.jpg','splf':'bajram-nebihi','vrnf':'fc-augsburg-91'}]}";
		    PlayerBuilder.FromKickerJsonHash(ovTeamPlayerElements);
		    	
			Console.WriteLine("\nWaiting . . .");
			Console.ReadKey(true);
		}
	}
}
