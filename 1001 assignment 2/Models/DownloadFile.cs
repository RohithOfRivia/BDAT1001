using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assi2_Data_Transmission.Models
{
    internal class DownloadFile
    { //File to download
        static string remoteDownloadFilePath = "200504198 Rohith Kumar/info.csv";
        //Create copy of file
        static string localDownloadFileDestination = @"D:\Georgian\Sem 1\1001 Information Encoding Standards\Assignment 2\info2.csv";
        public void fileDownload(string url, string username, string password)
        {
            string output;
            url = url + remoteDownloadFilePath;
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.DownloadFile;//method of transaction
            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(username, password);
            //Indicate Binary so that any file type can be downloaded
            request.UseBinary = true;
            try
            {
                //Create an instance of a Response object
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //Request a Response from the server
                using (Stream stream = response.GetResponseStream())
                {
                    //Build a variable to hold the data
                    byte[] buffer = new byte[1024]; //1 Mb chucks
                    //Establish a file stream to collect data from the response
                    using (FileStream fs = new FileStream(localDownloadFileDestination, FileMode.Create))
                    {
                        //Read data from the stream
                        //"ReadCount" is a variable holding length of byte array
                        int ReadCount = stream.Read(buffer, 0, buffer.Length);
                        //Loop until the stream data is complete
                        while (ReadCount > 0)
                        {
                            //Write the data to the file
                            fs.Write(buffer, 0, ReadCount);
                            //Read data from the stream at the rate of the size of the buffer
                            ReadCount = stream.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
                Console.WriteLine("Downloaded Complete...");
            }
            catch (Exception e)
            {
                //Something went wrong
                Console.WriteLine(e.Message);
            }
        }
    }
}

