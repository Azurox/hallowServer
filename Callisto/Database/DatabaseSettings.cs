﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Callisto.Database
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}