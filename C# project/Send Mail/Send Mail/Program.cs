using System;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Release 08.07.2018
namespace Send_Mail
{
    class Program
    {
        public const int TryNumber = 4;
        public static int TryCount = 0;

        public static string StrSMTP = null;
        public static string StrSenderEmail;
        public static string StrSenderPass;
        public static string StrReseiverEmail;
        public static string StrEmailTitle;
        public static string StrEmailText;
        public static string StrIpAdress;
        public static string StrDeletedFileFolder;
        public static string StrLaunchBatFolder;


        public static int FlagSendEmail;
        public static int FlagDeleteFile;
        public static int FlagLaunchBat;


        public static DateTime StartTime = DateTime.Now;
       [STAThread]
        static void Main(string[] args)
        {
            if(!IsElevantedCheck())
            {
                Console.WriteLine("Run as administrator!");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.WriteLine("Enter Ip Adress: ");
            StrIpAdress = Console.ReadLine();

            Console.WriteLine("Send Email?(1 or 0) ");
            FlagSendEmail = Convert.ToInt32(Console.Read());

            Console.ReadLine(); //console input delay

            if (FlagSendEmail == '1')
            {
                Console.ReadLine(); //console input delay

                Console.WriteLine("Default KELAN email?");
                if (Convert.ToInt32(Console.Read()) != '1')
                {
                    Console.ReadLine(); //console input delay

                    Console.WriteLine("Enter smtp: ");
                    StrSMTP = Console.ReadLine();
                    Console.ReadLine(); //console input delay

                    Console.WriteLine("Enter sender email: ");
                    StrSenderEmail = Console.ReadLine();
                    Console.ReadLine(); //console input delay

                    Console.WriteLine("Enter sender pass: ");
                    StrSenderPass = Console.ReadLine();
                    Console.ReadLine(); //console input delay

                    Console.WriteLine("Enter reseiver email: ");
                    StrReseiverEmail = Console.ReadLine();
                    Console.ReadLine(); //console input delay

                    Console.WriteLine("Enter email title: ");
                    StrEmailTitle = Console.ReadLine();
                    Console.ReadLine(); //console input delay

                    Console.WriteLine("Enter email text: ");
                    StrEmailText = Console.ReadLine();
                    Console.ReadLine(); //console input delay
                }

                Console.WriteLine("Try send email....");
                if (StrSMTP == null)
                    /* SendEmail ( data)*/;

                else
                    SendMail(StrSMTP, StrSenderEmail, StrSenderPass, StrReseiverEmail, StrEmailTitle, StrEmailText);

                Console.ReadLine(); //console input delay
                Console.WriteLine("You recieved email?");                
                if (Convert.ToInt32(Console.Read()) != '1')
                {
                    Console.WriteLine("Error send email. Exit!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                Console.ReadLine(); //console input delay
            }



            Console.WriteLine("Delete file?(1 or 0) ");            
            FlagDeleteFile = Convert.ToInt32(Console.Read());

            Console.ReadLine(); //console input delay

            if (FlagDeleteFile == '1')
            {
                Console.WriteLine("Enter folder: ");               
                StrDeletedFileFolder = Console.ReadLine();               
                Console.WriteLine(System.IO.File.Exists(StrDeletedFileFolder) ? "File found!" : "File does not exist.");
            }

            Console.WriteLine("Launching Bat?(1 or 0) ");
            FlagLaunchBat = Convert.ToInt32(Console.Read());

            Console.ReadLine(); //console input delay

            if (FlagLaunchBat == '1')
            {
                Console.WriteLine("Enter folder: ");
                StrLaunchBatFolder = Console.ReadLine();
                Console.WriteLine(System.IO.File.Exists(StrLaunchBatFolder) ? "Bat found!" : "Bat does not exist.");
            }



            Console.Title = String.Format("Ip Adress: {0} Send Email: {1} File Folder: \"{2}\" LaunchBat {3}", StrIpAdress, FlagSendEmail-48, StrDeletedFileFolder, FlagLaunchBat - 48);

           //Ping remote machine
                PingServ();            
                Console.ReadKey();

        }

        //Send Email function
        public static void SendMail(string smtpServer, string from, string password,
                                    string mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 25;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }
        //Ping machine on IP adress, and send Email if we dont have it.
        public static void PingServ()
        {
             // Ping's the local machine.                
           while (true)
            {
                try
                {     //Ping remote machine
                    Ping pingSender = new Ping();
                    PingReply reply = pingSender.Send(StrIpAdress);
                    Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                    //Show runtime
                    System.Threading.Thread.Sleep(500);
                    DateTime NowDate = DateTime.Now;                    
                    Console.WriteLine("Work time: {0}\n", NowDate.Subtract(StartTime));
                    //If we have ping - return
                    if (reply.Status.ToString() == "Success")
                    {
                        TryCount = 0;

                    } else  
                    {
                        DontPing();
                    }                        
                   
                }
                catch (PingException)
                {
                    DontPing();
                }
                catch (Exception)
                {
                    Console.WriteLine("Another Eror!");
                    Environment.Exit(0);
                }
                
            }
        }   
        public static void DontPing()
        {   //Send email and delete file
            if (TryCount == TryNumber)
            {   
                System.Threading.Thread.Sleep(500);
                if (FlagSendEmail == '1')
                {
                    Console.WriteLine("No Ping, Email sended....");
                    try
                    {

                        /* SendEmail ( data)*/;
                       
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("Can't send Email!");
                    }
                }

                if (FlagLaunchBat == '1')
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = StrLaunchBatFolder;
                    proc.Start();
                    proc.WaitForExit();
                }

                if (FlagDeleteFile == '1')
                {
                    if (System.IO.File.Exists(StrDeletedFileFolder))
                        try
                        {
                            System.IO.File.Delete(StrDeletedFileFolder);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }                    
                }
               
                //Exit program
                Console.WriteLine("Ready.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            //If we don't exceeded TryNumber: Show message, wait and increment TryCount
            Console.WriteLine("BadPing, number try: {0}", TryCount);
            System.Threading.Thread.Sleep(1000);
            TryCount++;
        }
        public static bool IsElevantedCheck()
        {
            bool isElevated;
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);

            return (isElevated ? true : false);
        }
    }
}
