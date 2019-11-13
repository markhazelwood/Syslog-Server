using SyslogServer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTcp;
using SqliteWrapper;
using System.Data;
using AegisImplicitMail;

namespace SyslogServer
{
	static class Settings
	{
		public static int port;
		public static string ip;
		public static bool ssl;
		public static string PfxFilename;
		public static string PfxPassword;
		public static TcpServer _Server;
		public static DatabaseClient Sql;
		public static string Sqlitedb;
		public static string mailfrom;
		public static string mailto;
		public static string mailserver;
		public static int mailport;
		public static string mailusername;
		public static string mailpassword;
		
		
		
	}
	public class Program
    {
        public delegate void OnMessageReceived(Message message);
        public static event OnMessageReceived MessageReceived;
       
       [STAThread]
        static void Main()
        {
        	
            		Settings.port = Properties.Settings.Default.port;
			Settings.ip= Properties.Settings.Default.ip;
			Settings.ssl = Properties.Settings.Default.ssl;
			Settings.PfxFilename= Properties.Settings.Default.Pfxfilename;
			Settings.PfxPassword= Properties.Settings.Default.Pfxpassword;
			Settings.Sqlitedb = Properties.Settings.Default.sqlitedb;
			Settings.mailfrom= Properties.Settings.Default.mailfrom;
			Settings.mailto=Properties.Settings.Default.mailto;
			Settings.mailserver=Properties.Settings.Default.mailserver;
			Settings.mailport=Properties.Settings.Default.mailport;
			Settings.mailusername=Properties.Settings.Default.mailusername;
			Settings.mailpassword=Properties.Settings.Default.mailpassword;
			
			try
			{
            Settings.Sql = new SqliteWrapper.DatabaseClient(Settings.Sqlitedb, true);
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            string createTableQuery =
                "CREATE TABLE IF NOT EXISTS logs (id integer primary key,host text default NULL,facility varchar(10) default NULL,severity varchar(10) default NULL,date text default CURRENT_TIMESTAMP,msg text)";
            DataTable createTableResult = Settings.Sql.Query(createTableQuery);

           
            
            
            try
            {
	        Settings._Server = new TcpServer(Settings.ip, Settings.port, Settings.ssl, Settings.PfxFilename, Settings.PfxPassword);
		Settings._Server.ClientConnected = ClientConnected;
        	Settings._Server.ClientDisconnected = ClientDisconnected;
            	Settings._Server.DataReceived = DataReceived;
            	Settings._Server.MutuallyAuthenticate = false;
            	Settings._Server.AcceptInvalidCertificates = true;
            	Settings._Server.Start();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
		Settings._Server.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
static bool ClientConnected(string ipPort)
        {
            //MessageBox.Show("*** Client connected ","Data",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            return true;
        }

        static bool ClientDisconnected(string ipPort)
        {
            //MessageBox.Show("*** Client disconnected ","Data",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            return true;
        }        
        static bool DataReceived(string ipPort, byte[] data)
        {
             Regex _re = new Regex(@"^(?<PRI>\<\d{1,3}\>)?(?<HDR>(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\s[0-3][0-9]\s[0-9]{4}\s[0-9]{2}\:[0-9]{2}\:[0-9]{2}\s[^ ]+?\s)?:\s(?<MSG>.+)?", RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Compiled);

                Match m = _re.Match(Encoding.UTF8.GetString(data));
                if (m.Success)
                {
                    Message msg = new Message();

                    if (m.Groups["PRI"].Success)
                    {
                        string pri = m.Groups["PRI"].Value;
                        int priority = Int32.Parse(pri.Substring(1, pri.Length - 2));
                        msg.Facility = (FacilityType)Math.Floor((double)priority / 8);
                        msg.Severity = (SeverityType)(priority % 8);
                    }
                    else
                    {
                        msg.Facility = FacilityType.User;
                        msg.Severity = SeverityType.Notice;
                    }

                    if (m.Groups["HDR"].Success)
                    {
                        string hdr = m.Groups["HDR"].Value.TrimEnd();
                        int idx = hdr.LastIndexOf(' ');
                        msg.Datestamp = DateTime.ParseExact(hdr.Substring(0, idx), "MMM dd yyyy HH:mm:ss", null);
                        msg.Hostname = hdr.Substring(idx + 1);
                    }
                    else
                    {
                        msg.Datestamp = DateTime.Now;
                        
                    }

                    msg.Content = m.Groups["MSG"].Value;
                    msg.RemoteIP = ipPort;
                    msg.LocalDate = DateTime.Now;

                    if (MessageReceived != null)
                    {
                        MessageReceived(msg);
                        Dictionary<string, object> d1 = new Dictionary<string, object>();
            			d1.Add("host", msg.Hostname);
            			d1.Add("facility", msg.Facility);
            			d1.Add("severity", msg.Severity);
            			d1.Add("date", msg.Datestamp);
            			d1.Add("msg", msg.Content);
            			Settings.Sql.Insert("logs", d1);
            			
            			try
            {
     
     //Generate Message 
     var mymessage = new MimeMailMessage();
     mymessage.From = new MimeMailAddress(Properties.Settings.Default.mailfrom);
     mymessage.To.Add(Properties.Settings.Default.mailto);
     mymessage.Subject = "ASA Log - " + msg.Hostname  + " - " + msg.Severity;
     mymessage.Body = Encoding.UTF8.GetString(data);
     
     //Create Smtp Client
     var mailer = new MimeMailer(Properties.Settings.Default.mailserver, Properties.Settings.Default.mailport);
     mailer.User= Properties.Settings.Default.mailusername;
     mailer.Password = Properties.Settings.Default.mailpassword;
     mailer.SslType = SslMode.Ssl;
     mailer.AuthenticationMode = AuthenticationType.Base64;           				
     
     mailer.SendMailAsync(mymessage);
            

	
            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message,"Failed to send email with the following error:",MessageBoxButtons.OK);
                
            }			

                    }
                  
                }
            
        
    
            return true;
        }
    }

    public enum FacilityType
    {
        Kern, User, Mail, Daemon, Auth, Syslog, LPR, News, UUCP, Cron, AuthPriv, FTP, NTP,
        Audit, Audit2, CRON2, Local0, Local1, Local2, Local3, Local4, Local5, Local6, Local7
    };

    public enum SeverityType { Emergency, Alert, Critical, Error, Warning, Notice, Informational, Debug };

    public class Message
    {
        public FacilityType Facility { get; set; }
        public SeverityType Severity { get; set; }
        public DateTime Datestamp { get; set; }
        public string Hostname { get; set; }
        public string Content { get; set; }
        public string RemoteIP{ get; set; }
        public DateTime LocalDate { get; set; }
    }

    public static class PredicateExtensions
    {
        public static Predicate<T> And<T>(this Predicate<T> original, Predicate<T> newPredicate)
        {
            return t => original(t) && newPredicate(t);
        }

        public static Predicate<T> Or<T>(this Predicate<T> original, Predicate<T> newPredicate)
        {
            return t => original(t) || newPredicate(t);
        }

        public static Predicate<T> Not<T>(this Predicate<T> original)
        {
            return t => !original(t);
        }
    }
}
