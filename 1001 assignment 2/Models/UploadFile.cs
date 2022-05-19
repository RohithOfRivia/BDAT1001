using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assi2_Data_Transmission.Models
{
    internal class UploadFile
    {
        static string localUploadFilePath = @"D:\Georgian\Sem 1\1001 Information Encoding Standards\Assignment 2\info2.csv";
        //local file path to upload";
        public void FileUpload(string url, string username, string password)
        {
            string filename = "200504198 Rohith Kumar/info2.csv";  //filename on FTP
            string remoteUploadFileDestination = "" + filename;   //directory on server
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url + remoteUploadFileDestination);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            // Copy the contents of the file to the request stream.
            byte[] fileContents;
            using (StreamReader sourceStream = new StreamReader(localUploadFilePath)) //create testfile.txt on debug folder of your application with data 
            {
                fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            }
            request.ContentLength = fileContents.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Console.WriteLine($"Upload File Complete...");
            }
        }
    }
}
