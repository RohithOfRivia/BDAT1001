using Assi2_Data_Transmission.Models;
//Task 1

GetDirectory get = new GetDirectory();
string output_get = get.GetDirectoryList(Constants.FTP.BaseUrl, Constants.FTP.Username, Constants.FTP.Password);

//Task 2
DownloadFile download = new DownloadFile();
download.fileDownload(Constants.FTP.BaseUrl, Constants.FTP.Username, Constants.FTP.Password);

//Task 3
UploadFile upload = new UploadFile();
upload.FileUpload(Constants.FTP.BaseUrl, Constants.FTP.Username, Constants.FTP.Password);

//Task 4
DataAggregation data = new DataAggregation();
data.PerformDataAggregation(output_get);