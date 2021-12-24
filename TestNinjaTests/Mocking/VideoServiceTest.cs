using TestNinja.Mocking;
using TestNinja.Mocking.Refactored;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestNinjaTests.Mocking
{
    public class VideoServiceTest
    {
        [Fact]
        public void ReadVideoTitle_EmptyFile_ReturnsError()
        {
            var fileReader = new Mock<IFileReader>();
            fileReader.Setup(fr => fr.ReadFromFile(It.IsAny<string>())).Returns("");

            var vs = new VideoService(fileReader.Object);

            var result = vs.ReadVideoTitle();

            Assert.Contains("Error", result, StringComparison.InvariantCultureIgnoreCase);


        }

        [Fact]
        public void ReadVideoTitle_ValidFile_ReturnsTitle()
        {
            var fileReader = new Mock<IFileReader>();
            fileReader.Setup(fr => fr.ReadFromFile(It.IsAny<string>())).Returns(@"{""Title"": ""a""}");

            var vs = new VideoService(fileReader.Object);

            var result = vs.ReadVideoTitle();

            Assert.Contains("a", result);


        }
        
        [Fact]
        public void GetUnProcessedVideosAsCsv_whenCalled_ReturnsList()
        {
            var vr = new Mock<IVideoRepository>();
            vr.Setup(vr => vr.GetUnprocessedVideosAsCsv()).Returns(
                new List<Video> 
                {
                    new Video {Id = 1},
                    new Video {Id = 2}
                }
            );

            var vs = new VideoService(null, vr.Object);

            var result = vs.GetUnprocessedVideosAsCsv();

            Assert.Contains("1,2", result);


        } 
        
        [Fact]
        public void GetUnProcessedVideosAsCsv_whenCalled_ReturnsEmptyList()
        {
            var vr = new Mock<IVideoRepository>();
            vr.Setup(vr => vr.GetUnprocessedVideosAsCsv()).Returns(
                new List<Video>() 
            );

            var vs = new VideoService(null, vr.Object);

            var result = vs.GetUnprocessedVideosAsCsv();

            Assert.Contains("", result);


        }
    }
}