using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private readonly IDownloadHelper _downloadHelper;

        public InstallerHelper(IDownloadHelper downloadHelper)
        {
            _downloadHelper = downloadHelper; 
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            
            try
            {
                _downloadHelper.DownloadFile(string.Format("http://example.com/{0}/{1}",
                            customerName, installerName), _setupDestinationFile);
                
                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }

    public class DownloadHelper : IDownloadHelper
    {

        public void DownloadFile(string url, string destinationPath)
        {
            var client = new WebClient();

            client.DownloadFile(url, destinationPath);
        }
    }

    public interface IDownloadHelper
    {
        void DownloadFile(string url, string destinationPath);
    }
}