﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tiny.RestClient.Tests
{
    [TestClass]
    public class StatusRangeTests : BaseTest
    {
        [TestMethod]
        public async Task GetStatus500ResponseAllowed()
        {
            var client = GetNewClient();
            client.Settings.HttpStatusCodeAllowed.AllowAllStatus = true;

            var response = await client.
                GetRequest("GetTest/Status500Response").
                ExecuteAsync<IEnumerable<string>>();
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetStatus409ResponseAllowed()
        {
            var client = GetNewClient();
            client.Settings.HttpStatusCodeAllowed.Add(new HttpStatusRange(400, 410));

            var response = await client.
                GetRequest("GetTest/Status409Response").
                ExecuteAsync<IEnumerable<string>>();
            Assert.IsNotNull(response);
        }
    }
}