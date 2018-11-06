﻿using NUnit.Framework;

namespace Coinbase.Tests
{
   [TestFixture]
   public class CoinbaseApiKeyTests : ServerTest
   {
      public string apiKey = "DBBD0428-B818-4F53-A5F4-F553DC4C374C";
      private CoinbaseApi api;

      [SetUp]
      public void BeforeEachTest()
      {
         api = new CoinbaseApi(new Config{ ApiKey = "", ApiSecret = ""});
      }

      [TearDown]
      public void AfterEachTest()
      {
         EnsureEveryRequestHasCorrectHeaders();
         this.server.Dispose();
      }

      private void EnsureEveryRequestHasCorrectHeaders()
      {
         server.ShouldHaveMadeACall()
            .WithHeader(HeaderNames.Version, CoinbaseApi.ApiVersionDate)
            .WithHeader(HeaderNames.AccessKey, apiKey)
            .WithHeader("User-Agent", CoinbaseApi.UserAgent);
      }


   }
}