using System.Net.Http;
using System.Net;
using TestNinja.Mocking;
using TestNinja.Mocking.Refactored;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Moq.Contrib.HttpClient;

namespace TestNinjaTests.Mocking
{
    public class GetJokesTest
    {
        [Fact]
        public void FetchRandomJokeTest()
        {
            var httpHandler = new Mock<HttpMessageHandler>();
            httpHandler.SetupRequest(HttpMethod.Get, GetJokes.endpoint).ReturnsResponse(HttpStatusCode.OK, @"{""id"":""123"", ""joke"":""haha"", ""status"": 200}");
            var httpClient = httpHandler.CreateClient();
            var jokes = new GetJokes(httpClient);

            var result = jokes.FetchRandomJoke();

            Assert.Equal("123", result.Id);
            Assert.Equal("haha", result.Joke);
            Assert.Equal(200, result.Status);
        }

        [Fact]
        public void PostGibbersishTest()
        {
            var httpHandler = new Mock<HttpMessageHandler>();
            httpHandler
            .SetupRequest(HttpMethod.Post, GetJokes.postEndpoint, request => request.Content.ToString() == new StringContent(@"{""data"" : ""Hi There""}").ToString())
            .ReturnsResponse(HttpStatusCode.OK);
            var httpClient = httpHandler.CreateClient();
            var jokes = new GetJokes(httpClient);

            var result = jokes.PostGibberish();

            Assert.Equal(200, result);
        }
        
    }
}