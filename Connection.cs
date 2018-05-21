using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace LeapProject_1
{
    class Connection
    {
       
        private string host = null;
        private string user = null;
        private string pass = null;
        private FtpWebRequest ftpRequest = null;
        private FtpWebResponse ftpResponse = null;
        private Stream ftpStream = null;
        private int bufferSize = 2048;

           public Connection(string hostIP, string userName, string password) { host = hostIP; user = userName; pass = password; }


           /* Get the Size of a File */
           public string getFileSize(string fileName)
           {
               try
               {
                   /* Create an FTP Request */
                   ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + fileName);
                   /* Log in to the FTP Server with the User Name and Password Provided */
                   ftpRequest.Credentials = new NetworkCredential(user, pass);
                   /* When in doubt, use these options */
                   ftpRequest.UseBinary = true;
                   ftpRequest.UsePassive = true;
                   ftpRequest.KeepAlive = true;
                   /* Specify the Type of FTP Request */
                   ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                   /* Establish Return Communication with the FTP Server */
                   ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                   /* Establish Return Communication with the FTP Server */
                   ftpStream = ftpResponse.GetResponseStream();
                   /* Get the FTP Server's Response Stream */
                   StreamReader ftpReader = new StreamReader(ftpStream);
                   /* Store the Raw Response */
                   string fileInfo = null;
                   /* Read the Full Response Stream */
                   try { while (ftpReader.Peek() != -1) { fileInfo = ftpReader.ReadToEnd(); } }
                   catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                   /* Resource Cleanup */
                   ftpReader.Close();
                   ftpStream.Close();
                   ftpResponse.Close();
                   ftpRequest = null;
                   /* Return File Size */
                   return fileInfo;
               }
               catch (Exception ex) { Console.WriteLine(ex.ToString()); }
               /* Return an Empty string Array if an Exception Occurs */
               return "";
           }
    }
}
