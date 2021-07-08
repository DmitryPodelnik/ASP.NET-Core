using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Models
{
    static internal class Logging
    {
        static internal ILoggerFactory LoggerFactory { get; set; }
        static internal ILogger CreateLogger<t>() => LoggerFactory.CreateLogger<t>();
        static internal ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);
    }
}
