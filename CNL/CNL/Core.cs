using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;

[assembly: AssemblyVersion("1.2.*")] //Set Version


namespace CNL
{

    class Core
    {

        //Method for opening console
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


        static readonly string VERSION = Assembly.GetExecutingAssembly().GetName().Version + " (Config: 1.1)"; //Version in string form in order to be able to write in console

        private static bool loggedIn; //Static variable to be able to determine whether logged in or not through certificate check


        static void Main(string[] args)
        {

            string[] data;

            //Load logindata form hard disk
            if (Load.SaveFileExists())
            {
                data = Load.LoadSave();
            }
            else //Save file does not exist
            {
                Console.WriteLine("Save file does not exist!");
                MessageBox.Show("Save file does not exist! Please execute CNL-Options first!", "CNL: Error while startup!");
                return;
            }

            //Some error occured with reading save file
            if (data == null || data.Length < (int) Load.Data.LENGTH)
            {
                MessageBox.Show("Save file seems to be corrupted! Please delete and recreate save-file in CNL-Options!", "CNL: Error while startup!");
                Console.WriteLine("Warning, loading save failed! Terminating");
                return;
            }

            //If debug mode is activated open console
            if (int.Parse(data[(int) Load.Data.DEBUG]) == 1)
            {
                AllocConsole();
            }

            Console.WriteLine("Version: " + VERSION);



            //Actual process starts here
            using (WebClient client = new WebClient())
            {
                //Login data for POST request
                NameValueCollection collection = new NameValueCollection();
                collection.Add("inputStr", "");
                collection.Add("escapeUser", data[(int)Load.Data.USER].Replace(@"\\", @"\\\\"));
                collection.Add("user", data[(int)Load.Data.USER]);
                collection.Add("passwd", data[(int)Load.Data.PW]);
                collection.Add("ok", "Login");

                //Method to accept Campus Certificate
                ServicePointManager.ServerCertificateValidationCallback += checkCertificate;

                Console.WriteLine("Posting...");

                //Set HTML Headers
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:43.0) Gecko/20100101 Firefox/43.0");
                client.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                client.Headers.Add("Accept-Language", "de,en-US;q=0.7,en;q=0.3");
                client.Headers.Add("Accept-Encoding", "gzip, deflate");
                client.Headers.Add("DNT", "1");


                //Load time for checking connection after login (0 if no checking is wanted)
                string checkConStr = data[(int)Load.Data.CHECK]; 
                int checkTimeout;
                if (String.IsNullOrWhiteSpace(checkConStr))
                {
                    checkTimeout = 0;
                }
                else
                {
                    checkTimeout = int.Parse(checkConStr) * 60000;
                }

                //Initial wait for OS to set up
                Console.WriteLine("Waiting for OS setup...");
                Thread.Sleep(350);

                //Do-While for checking after login
                do
                {
                    loggedIn = false;

                    //Do-While for retries if login fails
                    int triesLeft = int.Parse(data[(int)Load.Data.RETRY]); //Load try amount
                    do
                    {
                        //Try google connection
                        try
                        {
                            Console.WriteLine("Trying to connect to Google (http://www.google.at/)...");

                            //Create GET request to Google
                            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://www.google.at/"); //Already tried only using "HEAD" Method, results in connection-closed-exception though. Probably because Campus Router doesn't accept "HEAD" requests
                            req.AllowAutoRedirect = false;

                            //Analyze response from Server, whether redirect from router or correct answer from Google
                            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
                            {
                                if (resp.StatusCode == HttpStatusCode.Redirect)
                                {
                                    //Got redirected to login Page, send POST request over HTTPS to router
                                    Console.WriteLine("Redirected to login page. Trying to login...");
                                    client.UploadValuesAsync(new Uri("https://www.google.at:6082/php/uid.php?vsys=1&url=http://www.google.at%2f"), "POST", collection);

                                    //Cancel request if getting no answer after 5 Seconds
                                    Thread.Sleep(5000);
                                    client.CancelAsync();
                                    //In some cases you may get logged in even though you don't get an answer from the router, therefore checking whether logged in or not after cancel
                                    if (loggedIn)
                                    {
                                        Console.WriteLine("Now logged in!");
                                        goto Done;
                                    }
                                    if (triesLeft < 0) //infinite
                                        Console.WriteLine("Canceled attempt! " + "Retrying...");
                                    else
                                    { 
                                        triesLeft--;
                                        Console.WriteLine("Canceled attempt! " + triesLeft + " attempts left.");
                                    }
                                }
                                else if (resp.StatusCode == HttpStatusCode.OK) //Got OK response from Google
                                {
                                    Console.WriteLine("Connect to Google successful, already logged in!");
                                    goto Done;
                                }
                            }
                        }
                        catch (WebException ex)
                        {
                            //Some unexpected network error
                            if(triesLeft < 0)
                            {
                                Console.WriteLine("Error: " + ex.Status + "... (Retrying infinitely!)");
                            }
                            else
                            {
                                triesLeft--;
                                Console.WriteLine("Error: " + ex.Status + " (" + triesLeft + " tries left)");
                            }
                            //Waiting three seconds before trying again when network error occurs
                            Thread.Sleep(3000);
                        }
                    } while (triesLeft != 0); //if triesLeft < 0, then user chose infinite tries in CNLOptions

                //Logged in or tries left = 0
                Done:
                    Console.WriteLine("Done Posting!");
                    if (checkTimeout != 0)
                    {
                        Console.WriteLine("Waiting " + checkTimeout + "ms for next check! (That is " + (float)checkTimeout / 1000 / 60 + " minute(s)!)");
                    }
                    Thread.Sleep(checkTimeout);
                } while (checkTimeout != 0); // checkTimeout = 0 if user chose not to check after login

            }
            Console.WriteLine("Program finished!");
            Console.ReadLine();
        }



        private static bool checkCertificate(object sender, X509Certificate certif, X509Chain chain, SslPolicyErrors errors)
        {
            // If the certificate is a valid, signed certificate, return true. In our case this means we successfully connected to Google, hence setting loggedIn to true
            if (errors == SslPolicyErrors.None)
            {
                loggedIn = true;
                return true;
            }
            // If there are errors in the certificate chain, look at each error to determine the cause.
            if ((errors & SslPolicyErrors.RemoteCertificateChainErrors) != 0)
            {
                if (chain != null && chain.ChainStatus != null)
                {
                    foreach (X509ChainStatus status in chain.ChainStatus)
                    {
                        if ((certif.Subject == certif.Issuer) && (status.Status == X509ChainStatusFlags.UntrustedRoot))
                        {
                            // Self-signed certificates with an untrusted root (campus certificate) are valid.
                            continue;
                        }
                        else
                        {
                            if (status.Status != X509ChainStatusFlags.NoError)
                            {
                                // If there are any other errors in the certificate chain, the certificate is invalid.
                                return false;
                            }
                        }
                    }
                }
                // When processing reaches this line, the only errors in the certificate chain are
                // untrusted root errors for self-signed certificates. These certificates are valid for Campus Router.
                if (certif.Issuer.Equals("E=office@sstw.at, CN=172.16.14.1, OU=IT, O=SSTW, S=Salzburg, C=AT"))
                    return true;
                else
                    return false;
            }
            else
            {
                // In all other cases, return false.
                return false;
            }
        }
    }
}
