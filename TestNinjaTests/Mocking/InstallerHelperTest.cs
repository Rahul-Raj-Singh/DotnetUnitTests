using System.Net;
using TestNinja.Mocking;
using TestNinja.Mocking.Refactored;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestNinjaTests.Mocking
{
    public class InstallerHelperTest
    {
        [Fact]
        public void DownloadInstaller_WhenCalled_ThrowsException()
        {
            var helper = new Mock<IDownloadHelper>();
            helper
            .Setup(h => h.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
            .Throws<WebException>();

            var installerHelper = new InstallerHelper(helper.Object);
            var result = installerHelper.DownloadInstaller("", "");

            Assert.False(result);

        }
        
        [Fact]
        public void DownloadInstaller_WhenCalled_DownloadsFile()
        {
            var helper = new Mock<IDownloadHelper>();
            // helper
            // .Setup(h => h.DownloadFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            // .Throws<WebException>();

            var installerHelper = new InstallerHelper(helper.Object);
            var result = installerHelper.DownloadInstaller("", "");

            Assert.True(result);


        }
    }
}