using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace TestNinja.Mocking.Refactored
{
    public class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetUnprocessedVideosAsCsv()
        {

            using var context = new VideoContext();

             var videos = 
                    (from video in context.Videos
                    where !video.IsProcessed
                    select video).ToList();

            return videos;
        }
        
    }

    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideosAsCsv();
    }
}