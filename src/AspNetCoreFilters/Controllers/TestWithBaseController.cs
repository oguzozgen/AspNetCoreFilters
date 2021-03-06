﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreFilters.Filters.ActionFilters;
using Microsoft.Extensions.Logging;

namespace AspNetCoreFilters.Controllers
{
    [ServiceFilter(typeof(ClassConsoleLogActionOneFilter))]
    [Route("api/[controller]")]
    public class TestWithBaseController : BaseController
    {
        private readonly ILogger _logger;

        public TestWithBaseController(ILoggerFactory loggerFactory): base(loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("TestWithBaseController");
        }

        // GET: api/test
        [HttpGet]
        [HttpGet("getall")]
        [ServiceFilter(typeof(ConsoleLogActionOneFilter))]
        [ServiceFilter(typeof(ConsoleLogActionTwoFilter))]
        public IEnumerable<string> GetAll()
        {
            _logger.LogInformation("Executing Http Get all");
            return new string[] { "test data one", "test data two" };
        }
    }
}
